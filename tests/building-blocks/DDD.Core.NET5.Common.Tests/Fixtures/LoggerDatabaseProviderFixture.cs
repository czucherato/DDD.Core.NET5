using Moq;
using Xunit;
using System;
using DDD.Core.NET5.Common.Logging;

namespace DDD.Core.NET5.Common.Tests.Fixtures
{
    [CollectionDefinition(nameof(LoggerDatabaseProviderCollection))]
    public class LoggerDatabaseProviderCollection : ICollectionFixture<LoggerDatabaseProviderFixture> { }

    public class LoggerDatabaseProviderFixture : IDisposable
    {
        public LoggerDatabaseProvider<FakeUser> Create_Valid_LoggerDatabaseProvider()
        {
            var logRepository = new Mock<ILogRepository>().Object;
            return new LoggerDatabaseProvider<FakeUser>(logRepository);
        }

        public void Dispose() { }
    }
}