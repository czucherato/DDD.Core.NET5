using FluentValidation.Results;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Handlers
{
    public abstract class CommandHandler : Handler
    {
        protected CommandHandler(ValidationResult validationResult)
            : base(validationResult) { }

        protected bool Validate<T, U, I>(T command) where T : CommandRequest<U, I>
        {
            var result = command.IsValid();
            foreach (var error in command.ValidationResult.Errors)
            {
                _validationResult.Errors.Add(error);
            }

            return result;
        }
    }
}