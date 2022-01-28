using Xunit;
using System;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Tests.Messages
{
    public class CommandResponseTests
    {
        [Fact(DisplayName = "Create valid CommandResponse")]
        [Trait("CommandResponse", "Messages Tests")]
        public void Create_Valid_CommandResponse()
        {
            //Arrange
            var id = Guid.NewGuid();
            var fakeDataSource = new FakeDataSource();
            var fakeCommand = new FakeCommand();

            //Act
            var response = new CommandResponseImpl(id, fakeDataSource, fakeCommand, typeof(FakeCommand).ToString(), true);

            //Assert
            Assert.NotNull(response);
        }

        class CommandResponseImpl : CommandResponse<Guid>
        {
            public CommandResponseImpl(Guid aggregateId, object source, object command, string messageType, bool succeeded)
                : base(aggregateId, source, command, messageType, succeeded) { }
        }

        class FakeDataSource { }

        class FakeCommand { }


    }
}