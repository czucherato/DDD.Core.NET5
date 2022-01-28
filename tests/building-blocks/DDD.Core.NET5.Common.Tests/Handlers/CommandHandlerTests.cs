using Moq;
using Xunit;
using System;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Handlers;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Tests.Handlers
{
    public class CommandHandlerTests
    {
        [Fact(DisplayName = "CommandHandler validate returns true")]
        [Trait("CommandHandler", "Handler Tests")]
        public void CommandHandler_Validate_Returns_True()
        {
            //Arrange
            var commandMock = new Mock<CommandA>();
            commandMock.Setup(x => x.IsValid()).Returns(true);
            var commandHandler = new AggregateCommandHandler(new Mock<ValidationResult>().Object);

            //Act
            var result = commandHandler.ExternalValidate(commandMock.Object);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "CommandHandler validate returns false")]
        [Trait("CommandHandler", "Handler Tests")]
        public void CommandHandler_Validate_Returns_False()
        {
            //Arrange
            var commandMock = new Mock<CommandA>();
            commandMock.Setup(x => x.IsValid()).Returns(false);
            var commandHandler = new AggregateCommandHandler(new Mock<ValidationResult>().Object);

            //Act
            var result = commandHandler.ExternalValidate(commandMock.Object);

            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "CommandHandler validate with validation errors")]
        [Trait("CommandHandler", "Handler Tests")]
        public void CommandHandler_Validate_With_Validation_Errors()
        {
            //Arrange
            var command = new CommandB();
            command.AddError("Somer property", "Some error message");
            var commandHandler = new AggregateCommandHandler(new Mock<ValidationResult>().Object);

            //Act 
            var result = commandHandler.ExternalValidate(command);

            //Assert
            Assert.False(result);
        }
    }

    public class CommandA : CommandRequest<ValidationResult, Guid>
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }

    public class CommandB : CommandRequest<ValidationResult, Guid>
    {
        public override bool IsValid() => false;

        public void AddError(string property, string errorMessage) => ValidationResult.Errors.Add(new ValidationFailure(property, errorMessage));
    }

    public class AggregateCommandHandler : CommandHandler
    {
        public AggregateCommandHandler(ValidationResult validationResult)
            : base(validationResult) { }

        public bool ExternalValidate(CommandA command) => Validate<CommandA, ValidationResult, Guid>(command);

        public bool ExternalValidate(CommandB command) => Validate<CommandB, ValidationResult, Guid>(command);
    }
}
