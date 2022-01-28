using Xunit;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Handlers;

namespace DDD.Core.NET5.Common.Tests.Handlers
{
    public class QueryHandlerTests
    {
        [Fact(DisplayName = "QueryHandler instantiation")]
        [Trait("QueryHandler", "Handler Tests")]
        public void QueryHandler_Instantiation()
        {
            //Arrange & Act & Assert
            Assert.NotNull(new ExtendedQueryHandler(new ValidationResult()));

        }
    }

    public class ExtendedQueryHandler : QueryHandler
    {
        public ExtendedQueryHandler(ValidationResult validationResult)
            : base(validationResult) { }
    }
}