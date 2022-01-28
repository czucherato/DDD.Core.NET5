using MediatR;

namespace DDD.Core.NET5.Common.Messages
{
    public class Event<TId> : Message<TId>, INotification
    {
        public Event()
            : base() { }
    }
}