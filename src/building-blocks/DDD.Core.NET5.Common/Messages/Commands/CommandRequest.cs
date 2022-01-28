using MediatR;
using FluentValidation.Results;

namespace DDD.Core.NET5.Common.Messages.Commands
{
    public abstract class CommandRequest<T, TId> : Message<TId>, IRequest<T>
    {
        protected CommandRequest()
            : base() { }

        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public abstract bool IsValid();
    }
}