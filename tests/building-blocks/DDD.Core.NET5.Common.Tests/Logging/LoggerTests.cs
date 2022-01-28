using Xunit;
using System;
using Microsoft.Extensions.Logging;
using DDD.Core.NET5.Common.Tests.Fixtures;
using static DDD.Core.NET5.Common.Logging.Logger;

namespace DDD.Core.NET5.Common.Tests.Logging
{
    [Collection(nameof(LoggerCollection))]
    public class LoggerTests
    {
        public LoggerTests(LoggerFixture loggerFixture)
        {
            _loggerFixture = loggerFixture;
        }

        private readonly LoggerFixture _loggerFixture;

        [Fact(DisplayName = "Calling BeginScope method")]
        [Trait("Logger", "Logging Tests")]
        public void Calling_BeginScope_Method()
        {
            //Arrange
            var fakeState = new FakeState();
            var logger = _loggerFixture.Create_Valid_Logger();

            //Act
            var disposable = logger.BeginScope(fakeState);

            //Assert
            Assert.NotNull(disposable);
        }

        [Fact(DisplayName = "Create NoopDisposable instance")]
        [Trait("Logger", "Logging Tests")]
        public void Create_NoopDisposable_Instance()
        {
            //Arrange
            var noopDisposable = new NoopDisposable();

            //Act & Assert
            noopDisposable.Dispose();
        }

        [Theory(DisplayName = "Logger is enable by LogLevel")]
        [InlineData(LogLevel.Error)]
        [InlineData(LogLevel.Warning)]
        [InlineData(LogLevel.Information)]
        [Trait("Logger", "Logging Tests")]
        public void Logger_Is_Enabled_By_LogLevel(LogLevel loglevel)
        {
            //Arrange
            var logger = _loggerFixture.Create_Valid_Logger();

            //Act
            var isEnabled = logger.IsEnabled(loglevel);

            //Assert
            Assert.True(isEnabled);
        }

        [Fact(DisplayName = "Calling Log method")]
        [Trait("Logger", "Logging Tests")]
        public void Calling_Log_Method()
        {
            //Arrange
            var eventId = new EventId(1);
            var fakeState = new FakeState();
            var message = "Some exception";
            var exception = new Exception(message);
            var logger = _loggerFixture.Create_Valid_Logger();

            //Act & Assert
            logger.Log(LogLevel.Error, eventId, fakeState, exception, ExceptionFormatter);
        }

        private string ExceptionFormatter<TState>(TState state, Exception exception)
        {
            return exception?.Message;
        }

        class FakeState 
        {
            public Exception Exception { get; set; }
        }
    }
}