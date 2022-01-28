using Moq;
using Xunit;
using System.Linq;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Handlers;

namespace DDD.Core.NET5.Common.Tests.Handlers
{
    public class HandlerTests
    {
        [Fact(DisplayName = "Adding handler errors")]
        [Trait("Handler", "Handler Tests")]
        public void Adding_Handler_Errors()
        {
            //Arrange
            var validationResult = new Mock<ValidationResult>().Object;
            var handler = new ExtendedHandler(validationResult);

            //Act
            handler.ExternalAddError("Some error");

            //Assert
            Assert.True(handler.ContainsError());
        }

        [Fact(DisplayName = "Clearing handler errors")]
        [Trait("Handler", "Handler Tests")]
        public void Clearing_Handler_Errors()
        {
            //Arrange
            var validationResult = new Mock<ValidationResult>().Object;
            var handler = new ExtendedHandler(validationResult);
            handler.ExternalAddError("Some error");

            //Act
            handler.ExternalClearErrors();

            //Assert
            Assert.False(handler.ContainsError());
        }
    }

    public class ExtendedHandler : Handler
    {
        public ExtendedHandler(ValidationResult validationResult)
            : base(validationResult) { }

        public void ExternalAddError(string errorMessage) => AddError(errorMessage);

        public void ExternalClearErrors() => ClearErrors();

        public bool ContainsError() => _validationResult.Errors.Any();
    }
}