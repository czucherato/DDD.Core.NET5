using Xunit;
using System;
using DDD.Core.NET5.Common.Logging;
using Microsoft.Extensions.Logging;

namespace DDD.Core.NET5.Common.Tests.Logging
{
    public class LogTests
    {
        [Fact(DisplayName = "Create valid Log object")]
        [Trait("Log", "Logging Tests")]
        public void Create_Valid_Log_Object()
        {
            //Arrange
            var user = new FakeUser();
            var dataSource = new FakeDataSource();
            var fakeCommand = new FakeCommand();
            var exception = new Exception("Some exception");

            //Act
            var log = new Log(LogLevel.Error, user, dataSource, fakeCommand, typeof(FakeCommand).ToString(), exception.Message);

            //Assert
            Assert.NotNull(log);
        }

        public class FakeUser { }

        public class FakeDataSource { }

        public class FakeCommand { }
    }
}