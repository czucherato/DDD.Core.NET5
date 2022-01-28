using System;
using Microsoft.Extensions.Logging;

namespace DDD.Core.NET5.Common.Logging
{
    public class Logger : ILogger
    {
        public Logger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        private readonly ILogRepository _logRepository;

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Information || logLevel == LogLevel.Warning || logLevel == LogLevel.Error;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel == LogLevel.Error)
            {
                _logRepository.Register(new Log(LogLevel.Error, null, null, null, null, exception.Message ?? exception?.InnerException?.Message));
            }
        }

        public class NoopDisposable : IDisposable
        {
            public void Dispose() { }
        }
    }
}