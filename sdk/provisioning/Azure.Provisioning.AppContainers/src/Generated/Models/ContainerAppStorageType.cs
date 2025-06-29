// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

namespace Azure.Provisioning.AppContainers;

/// <summary>
/// Storage type for the volume. If not provided, use EmptyDir.
/// </summary>
public enum ContainerAppStorageType
{
    /// <summary>
    /// AzureFile.
    /// </summary>
    AzureFile,

    /// <summary>
    /// EmptyDir.
    /// </summary>
    EmptyDir,

    /// <summary>
    /// Secret.
    /// </summary>
    Secret,

    /// <summary>
    /// NfsAzureFile.
    /// </summary>
    NfsAzureFile,
}
