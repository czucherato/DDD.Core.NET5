using System.Threading.Tasks;
using DDD.Core.NET5.Common.Messages;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Mediator
{
    public interface IMediatorHandler
    {
        Task Publish<T, I>(T @event) where T : Event<I>;

        Task<U> Query<T, U, I>(T @params) where T : Query<U, I>;

        Task<U> Send<T, U, I>(T command) where T : CommandRequest<U, I>;
    }
}