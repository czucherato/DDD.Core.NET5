using System;
using Microsoft.Extensions.Logging;

namespace DDD.Core.NET5.Common.Logging
{
    public partial class LoggerDatabaseProvider<TUser> : ILoggerProvider
    {
        public LoggerDatabaseProvider(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        private readonly ILogRepository _logRepository;

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(_logRepository);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}