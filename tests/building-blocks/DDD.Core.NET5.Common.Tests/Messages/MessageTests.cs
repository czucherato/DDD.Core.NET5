using Xunit;
using System;
using DDD.Core.NET5.Common.Messages;

namespace DDD.Core.NET5.Common.Tests.Messages
{
    public class MessageTests
    {
        [Fact(DisplayName = "MessageType is properly filled")]
        [Trait("Message", "Messages Tests")]
        public void MessageType_Is_Properly_Filled()
        {
            //Arrange
            var message = new FakeMessage();

            //Act & Assert
            Assert.NotNull(message.MessageType);
        }

        [Fact(DisplayName = "TimeStamp is properly filled")]
        [Trait("Message", "Messages Tests")]
        public void TimeStamp_Is_Properly_Filled()
        {
            //Arrange
            var message = new FakeMessage();

            //Act & Assert
            Assert.True(message.TimeStamp > DateTime.MinValue);
        }

        [Fact(DisplayName = "AggregateId is properly filled")]
        [Trait("Message", "Messages Tests")]
        public void AggregateId_Is_Properly_Filled()
        {
            //Arrange
            var message = new FakeMessage();

            //Act
            message.AggregateIdExternalSet();

            //Assert
            Assert.True(message.AggregateId != Guid.Empty);
        }
    }

    public class FakeMessage : Message<Guid>
    {
        public void AggregateIdExternalSet() => AggregateId = Guid.NewGuid();
    }
}