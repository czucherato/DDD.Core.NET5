using System.Text.Json.Serialization;

namespace DDD.Core.NET5.Common.Messages.Commands
{
    public abstract class CommandResponse<TId>
    {
        public CommandResponse(TId aggregateId, object source, object command, string messageType, bool succeeded)
        {
            Source = source;
            Command = command;
            Succeeded = succeeded;
            MessageType = messageType;
            AggregateId = aggregateId;
        }

        [JsonIgnore]
        public object Command { get; set; }

        [JsonIgnore]
        public object Source { get; private set; }

        [JsonIgnore]
        public bool Succeeded { get; private set; }

        public TId AggregateId { get; private set; }

        [JsonIgnore]
        public string MessageType { get; private set; }
    }
}