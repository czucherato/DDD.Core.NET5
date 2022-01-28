using System;
using Microsoft.Extensions.Logging;

namespace DDD.Core.NET5.Common.Logging
{
    public class Log
    {
        protected Log()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }

        public Log(LogLevel logLevel, object user = null, object source = null, object command = null, string messageType = null, string exception = null)
            : this()
        {
            User = user;
            Source = source;
            Command = command;
            MessageType = messageType;
            LogLevel = logLevel;
            Exception = exception;
        }

        public Guid Id { get; private set; }

        public object User { get; private set; }

        public object Source { get; private set; }

        public object Command { get; private set; }

        public string MessageType { get; private set; }

        public LogLevel LogLevel { get; private set; }

        public string Exception { get; private set; }

        public DateTime CriadoEm { get; private set; }
    }
}