﻿using System;
using System.Threading;

namespace ENode.Commanding
{
    /// <summary>Represents the command execution async result.
    /// </summary>
    public class CommandAsyncResult
    {
        private readonly ManualResetEvent _waitHandle;
        private readonly Action<CommandAsyncResult> _callback;

        /// <summary>Represents whether the command execution is completed.
        /// </summary>
        public bool IsCompleted { get; private set; }
        /// <summary>Represents the id of aggregate root which was created or updated by the command.
        /// <remarks>Can be null if the command not effect any aggregate root.</remarks>
        /// </summary>
        public string AggregateRootId { get; private set; }
        /// <summary>Error message generated when executing the command.
        /// </summary>
        public string ErrorMessage { get; private set; }
        /// <summary>Error exception generated when executing the command.
        /// </summary>
        public Exception Exception { get; private set; }
        /// <summary>Represents whether the command execution has any error.
        /// </summary>
        public bool HasError
        {
            get
            {
                return ErrorMessage != null || Exception != null;
            }
        }

        /// <summary>Parameterized constructor.
        /// </summary>
        /// <param name="waitHandle"></param>
        public CommandAsyncResult(ManualResetEvent waitHandle)
        {
            if (waitHandle == null)
            {
                throw new ArgumentNullException("waitHandle");
            }
            _waitHandle = waitHandle;
        }
        /// <summary>Parameterized constructor.
        /// </summary>
        /// <param name="callback"></param>
        public CommandAsyncResult(Action<CommandAsyncResult> callback)
        {
            _callback = callback;
        }

        /// <summary>Complete the command execution async result.
        /// </summary>
        /// <param name="aggregateRootId"></param>
        /// <param name="errorMessage"></param>
        /// <param name="exception"></param>
        public void Complete(string aggregateRootId, string errorMessage, Exception exception)
        {
            IsCompleted = true;
            AggregateRootId = aggregateRootId;
            ErrorMessage = errorMessage;
            Exception = exception;

            if (_waitHandle != null)
            {
                _waitHandle.Set();
            }
            else if (_callback != null)
            {
                _callback(this);
            }
        }
    }
}
