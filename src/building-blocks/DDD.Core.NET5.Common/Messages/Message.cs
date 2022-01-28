using System;

namespace DDD.Core.NET5.Common.Messages
{
    public abstract class Message<TId>
    {
        protected Message()
        {
            TimeStamp = DateTime.Now;
            MessageType = GetType().Name;
        }

        public string MessageType { get; private set; }

        public TId AggregateId { get; protected set; }

        public DateTime TimeStamp { get; private set; }
    }
}