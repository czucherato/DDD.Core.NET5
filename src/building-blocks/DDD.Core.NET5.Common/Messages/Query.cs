using MediatR;

namespace DDD.Core.NET5.Common.Messages
{
    public abstract class Query<T, TId> : Message<TId>, IRequest<T>
    {
        protected Query()
            : base() { }
    }
}