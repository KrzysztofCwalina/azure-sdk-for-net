﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from playing audio.</summary>
    public class InterruptAudioAndAnnounceResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal InterruptAudioAndAnnounceResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="PlayEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="PlayEventResult"/> which contains either <see cref="PlayCompleted"/> event or <see cref="PlayFailed"/> event.</returns>
        public PlayEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCompleted)
                || filter.GetType() == typeof(PlayStarted)
                || filter.GetType() == typeof(PlayFailed)
                || filter.GetType() == typeof(PlayPaused)
                || filter.GetType() == typeof(PlayResumed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="PlayEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="PlayEventResult"/> which contains either <see cref="PlayCompleted"/> event or <see cref="PlayFailed"/> event.</returns>
        public async Task<PlayEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCompleted)
                || filter.GetType() == typeof(PlayStarted)
                || filter.GetType() == typeof(PlayFailed)
                || filter.GetType() == typeof(PlayPaused)
                || filter.GetType() == typeof(PlayResumed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static PlayEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            PlayEventResult result = default;
            switch (returnedEvent)
            {
                case PlayCompleted:
                    result = new PlayEventResult(true, (PlayCompleted)returnedEvent, null, null, null, null);
                    break;
                case PlayFailed:
                    result = new PlayEventResult(false, null, (PlayFailed)returnedEvent, null, null, null);
                    break;
                case PlayStarted:
                    result = new PlayEventResult(true, null, null, (PlayStarted)returnedEvent, null, null);
                    break;
                case PlayPaused:
                    result = new PlayEventResult(true, null, null, null, (PlayPaused)returnedEvent, null);
                    break;
                case PlayResumed:
                    result = new PlayEventResult(true, null, null, null, null, (PlayResumed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
