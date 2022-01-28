using Xunit;
using System;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Tests.Messages
{
    public class CommandTests
    {
        [Fact(DisplayName = "Inherited ValidationResult is not null")]
        [Trait("Command", "Messages Tests")]
        public void Inherited_ValidationResult_Is_Not_Null()
        {
            //Arrange & Act & Assert
            Assert.NotNull(new ExtendedCommand().ValidationResult);
        }

        [Fact(DisplayName = "Inherited class setting ValidationResult")]
        [Trait("Command", "Messages Tests")]
        public void Inherited_Class_Setting_ValidationResult()
        {
            //Arrange 
            var command = new ExtendedCommand();

            //Act 
            command.SetValidationResult();

            //Assert
            Assert.NotNull(command.ValidationResult);
        }

    }

    public class Result { }

    public class ExtendedCommand : CommandRequest<Result, Guid>
    {
        public void SetValidationResult()
        {
            ValidationResult = new ValidationResult();
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}