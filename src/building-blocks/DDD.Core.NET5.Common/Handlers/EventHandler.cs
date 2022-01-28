using FluentValidation.Results;

namespace DDD.Core.NET5.Common.Handlers
{
    public abstract class EventHandler : Handler
    {
        protected EventHandler(ValidationResult validationResult)
            : base(validationResult) { }
    }
}