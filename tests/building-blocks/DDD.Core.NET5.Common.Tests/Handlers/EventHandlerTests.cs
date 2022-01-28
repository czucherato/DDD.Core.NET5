using Xunit;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Handlers;

namespace DDD.Core.NET5.Common.Tests.Handlers
{
    public class EventHandlerTests
    {
        [Fact(DisplayName = "EventHandler instantiation")]
        [Trait("EventHandler", "Handler Tests")]
        public void EventHandler_Instantiation()
        {
            //Arrange & Act & Assert
            Assert.NotNull(new ExtendedEventHandler(new ValidationResult()));

        }
    }

    public class ExtendedEventHandler : EventHandler
    {
        public ExtendedEventHandler(ValidationResult validationResult)
            : base(validationResult) { }
    }
}