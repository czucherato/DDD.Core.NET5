using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DDD.Core.NET5.Common.Data;
using DDD.Core.NET5.Common.Mediator;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Handlers
{
    public abstract class BaseCommandHandlerBehavior<TRequest, TResponse, TId> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : CommandRequest<TResponse, TId>
        where TResponse : CommandResponse<TId>
    {
        public BaseCommandHandlerBehavior(
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler)
        {
            _unitOfWork = unitOfWork;
            _mediatorHandler = mediatorHandler;
        }

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMediatorHandler _mediatorHandler;

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}