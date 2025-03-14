﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using Microsoft.Data.SqlClient;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    /// <summary>
    /// These tests and helper classes were initially copied from
    /// <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/1.6.0-beta.3/test/OpenTelemetry.Instrumentation.SqlClient.Tests/SqlClientTests.cs" />.
    /// </summary>
    public class SqlClientDependencyTests : DocumentTestBase
    {
        private const string TestConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=MyDatabase";

        public SqlClientDependencyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void VerifySqlClientAttributes()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);
            // TODO: Replace this ActivityListener with an OpenTelemetry provider.
            using var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var dependencyActivity = activitySource.StartActivity(name: "TestActivityName", kind: ActivityKind.Client);
            Assert.NotNull(dependencyActivity);
            dependencyActivity.SetTag("db.system", "mssql");
            dependencyActivity.SetTag("db.name", "MyDatabase");
            dependencyActivity.SetTag("peer.service", "(localdb)\\MSSQLLocalDB");
            dependencyActivity.SetTag("db.statement", "select * from sys.databases");
            dependencyActivity.SetTag("customKey1", "customValue1");
            dependencyActivity.SetTag("customKey2", "customValue2");
            dependencyActivity.SetTag("customKey3", "customValue3");
            dependencyActivity.SetTag("customKey4", "customValue4");
            dependencyActivity.SetTag("customKey5", "customValue5");
            dependencyActivity.SetTag("customKey6", "customValue6");
            dependencyActivity.SetTag("customKey7", "customValue7");
            dependencyActivity.SetTag("customKey8", "customValue8");
            dependencyActivity.SetTag("customKey9", "customValue9");
            dependencyActivity.SetTag("customKey10", "customValue10");
            dependencyActivity.SetTag("customKey11", "customValue11");
            dependencyActivity.Stop();

            var dependencyDocument = DocumentHelper.ConvertToDependencyDocument(dependencyActivity);

            // ASSERT
            Assert.Equal("select * from sys.databases", dependencyDocument.CommandName);
            Assert.Equal(DocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal(dependencyActivity.Duration.ToString("c"), dependencyDocument.Duration);
            Assert.Equal("TestActivityName", dependencyDocument.Name);

            VerifyCustomProperties(dependencyDocument);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.True(dependencyDocument.Extension_IsSuccess);
        }

#if !NETFRAMEWORK // DiagnosticListener-based instrumentation is only available on .NET Core
        [Theory]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataAfterExecuteCommand, CommandType.StoredProcedure, "SP_GetOrders")]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataAfterExecuteCommand, CommandType.Text, "select * from sys.databases")]
        public void VerifySqlClientDependency(
            string beforeCommand,
            string afterCommand,
            CommandType commandType,
            string commandText)
        {
            using var sqlConnection = new SqlConnection(TestConnectionString);
            using var sqlCommand = sqlConnection.CreateCommand();

            var fakeSqlClientDiagnosticSource = new FakeSqlClientDiagnosticSource();

            var exportedActivities = new List<Activity>();
            using (var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSqlClientInstrumentation(options =>
                {
                    options.SetDbStatementForText = true;
                })
                .AddInMemoryExporter(exportedActivities)
                .Build())
            {
                var operationId = Guid.NewGuid();
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = commandType;

                var beforeExecuteEventData = new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = (long?)1000000L,
                };

                fakeSqlClientDiagnosticSource.Write(
                    beforeCommand,
                    beforeExecuteEventData);

                var afterExecuteEventData = new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = 2000000L,
                };

                fakeSqlClientDiagnosticSource.Write(
                    afterCommand,
                    afterExecuteEventData);

                tracerProvider.ForceFlush();
                WaitForActivityExport(exportedActivities);
            }

            var dependencyActivity = exportedActivities.First(x => x.Kind == ActivityKind.Client)!;
            PrintActivity(dependencyActivity);
            var dependencyDocument = DocumentHelper.ConvertToDependencyDocument(dependencyActivity);

            Assert.Equal(commandText, dependencyDocument.CommandName);
            Assert.Equal(DocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal(dependencyActivity.Duration.ToString("c"), dependencyDocument.Duration);
            Assert.Equal("MyDatabase", dependencyDocument.Name);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.True(dependencyDocument.Extension_IsSuccess);
        }
#endif

#if !NETFRAMEWORK // DiagnosticListener-based instrumentation is only available on .NET Core
        [Theory]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataWriteCommandError, CommandType.StoredProcedure, "SP_GetOrders")]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataWriteCommandError, CommandType.Text, "select * from sys.databases")]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataWriteCommandError, CommandType.StoredProcedure, "SP_GetOrders", true)]
        [InlineData(SqlClientConstants.SqlDataBeforeExecuteCommand, SqlClientConstants.SqlDataWriteCommandError, CommandType.Text, "select * from sys.databases", true)]
        public void VerifySqlClientDependencyWithException(
            string beforeCommand,
            string errorCommand,
            CommandType commandType,
            string commandText,
            bool recordException = false)
        {
            using var sqlConnection = new SqlConnection(TestConnectionString);
            using var sqlCommand = sqlConnection.CreateCommand();

            var fakeSqlClientDiagnosticSource = new FakeSqlClientDiagnosticSource();

            var exportedActivities = new List<Activity>();
            using (var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSqlClientInstrumentation(options =>
                {
                    options.SetDbStatementForText = true;
                    options.RecordException = recordException;
                })
                .AddInMemoryExporter(exportedActivities)
                .Build())
            {
                var operationId = Guid.NewGuid();
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = commandType;

                var beforeExecuteEventData = new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Timestamp = (long?)1000000L,
                };

                fakeSqlClientDiagnosticSource.Write(
                    beforeCommand,
                    beforeExecuteEventData);

                var commandErrorEventData = new
                {
                    OperationId = operationId,
                    Command = sqlCommand,
                    Exception = new System.Exception("Boom!"),
                    Timestamp = 2000000L,
                };

                fakeSqlClientDiagnosticSource.Write(
                    errorCommand,
                    commandErrorEventData);

                tracerProvider.ForceFlush();
                WaitForActivityExport(exportedActivities);
            }

            var dependencyActivity = exportedActivities.First(x => x.Kind == ActivityKind.Client)!;
            PrintActivity(dependencyActivity);
            var dependencyDocument = DocumentHelper.ConvertToDependencyDocument(dependencyActivity);

            Assert.Equal(commandText, dependencyDocument.CommandName);
            Assert.Equal(DocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal(dependencyActivity.Duration.ToString("c"), dependencyDocument.Duration);
            Assert.Equal("MyDatabase", dependencyDocument.Name);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.False(dependencyDocument.Extension_IsSuccess);
        }
#endif

        /// <summary>
        /// These tests and helper classes were initially copied from
        /// <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/1.6.0-beta.3/test/OpenTelemetry.Instrumentation.SqlClient.Tests/SqlClientTests.cs" />.
        /// </summary>
        private static class SqlClientConstants
        {
            internal const string SqlClientDiagnosticListenerName = "SqlClientDiagnosticListener";

            public const string SqlDataBeforeExecuteCommand = "System.Data.SqlClient.WriteCommandBefore";

            public const string SqlDataAfterExecuteCommand = "System.Data.SqlClient.WriteCommandAfter";

            public const string SqlDataWriteCommandError = "System.Data.SqlClient.WriteCommandError";
        }

        /// <summary>
        /// These tests and helper classes were initially copied from
        /// <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/1.6.0-beta.3/test/OpenTelemetry.Instrumentation.SqlClient.Tests/SqlClientTests.cs" />.
        /// </summary>
        private class FakeSqlClientDiagnosticSource : IDisposable
        {
            private readonly DiagnosticListener listener;

            public FakeSqlClientDiagnosticSource()
            {
                listener = new DiagnosticListener(SqlClientConstants.SqlClientDiagnosticListenerName);
            }

            public void Write(string name, object value)
            {
                if (listener.IsEnabled(name))
                {
                    listener.Write(name, value);
                }
            }

            public void Dispose()
            {
                listener.Dispose();
            }
        }
    }
}
