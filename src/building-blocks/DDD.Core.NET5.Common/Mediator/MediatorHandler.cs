using MediatR;
using System.Threading.Tasks;
using DDD.Core.NET5.Common.Messages;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<T, I>(T @event) where T : Event<I>
        {
            await _mediator.Publish(@event);
        }

        public async Task<U> Query<T, U, I>(T @params) where T : Query<U, I>
        {
            return await _mediator.Send(@params);
        }

        public async Task<U> Send<T, U, I>(T command) where T : CommandRequest<U, I>
        {
            return await _mediator.Send(command);
        }
    }
}