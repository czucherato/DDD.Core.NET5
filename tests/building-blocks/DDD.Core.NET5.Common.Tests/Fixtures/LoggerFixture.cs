using Moq;
using Xunit;
using System;
using DDD.Core.NET5.Common.Logging;
using Microsoft.Extensions.Logging;

namespace DDD.Core.NET5.Common.Tests.Fixtures
{
    [CollectionDefinition(nameof(LoggerCollection))]
    public class LoggerCollection : ICollectionFixture<LoggerFixture> { }
    public class LoggerFixture : IDisposable
    {
        public Logger Create_Valid_Logger()
        {
            var logRepository = new Mock<ILogRepository>();
            var exception = new Exception("Some exception");
            var log = new Log(LogLevel.Information, null, null, null, null, exception.Message);
            logRepository.Setup(x => x.Register(log));

            return new Logger(logRepository.Object);
        }

        public void Dispose() { }
    }
}