using FluentValidation.Results;

namespace DDD.Core.NET5.Common.Handlers
{
    public abstract class QueryHandler : Handler
    {
        protected QueryHandler(ValidationResult validationResult)
            : base(validationResult) { }
    }
}