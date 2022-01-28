using Xunit;
using DDD.Core.NET5.Common.Tests.Fixtures;

namespace DDD.Core.NET5.Common.Tests.Logging
{
    [Collection(nameof(LoggerDatabaseProviderCollection))]
    public class LoggerDatabaseProviderTests
    {
        public LoggerDatabaseProviderTests(LoggerDatabaseProviderFixture loggerDatabaseProviderFixture)
        {
            _loggerDatabaseProviderFixture = loggerDatabaseProviderFixture;
        }

        private readonly LoggerDatabaseProviderFixture _loggerDatabaseProviderFixture;

        [Fact(DisplayName = "Create valid LoggerDatabaseProvider")]
        [Trait("LoggerDatabaseProvider", "Logging Tests")]
        public void Create_Valid_LoggerDatabaseProvider()
        {
            //Arrange & Act
            var loggerDataBaseProvider = _loggerDatabaseProviderFixture.Create_Valid_LoggerDatabaseProvider();

            //Assert
            Assert.NotNull(loggerDataBaseProvider);
        }

        [Fact(DisplayName = "Create logger instance")]
        [Trait("LoggerDatabaseProvider", "Logging Tests")]
        public void Create_Logger_Instance()
        {
            //Arrange
            var category = "New Category";
            var loggerDataBaseProvider = _loggerDatabaseProviderFixture.Create_Valid_LoggerDatabaseProvider();

            //Act
            var logger = loggerDataBaseProvider.CreateLogger(category);

            //Assert
            Assert.NotNull(logger);
        }

        [Fact(DisplayName = "Calling dispose method")]
        [Trait("LoggerDatabaseProvider", "Logging Tests")]
        public void Calling_Dipose_Method()
        {
            //Arrange
            var loggerDataBaseProvider = _loggerDatabaseProviderFixture.Create_Valid_LoggerDatabaseProvider();

            //Act & Assert
            loggerDataBaseProvider.Dispose();
        }
    }
}