using System;
using System.Runtime.Serialization;

namespace DDD.Core.NET5.Common.DomainObjects
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message) : base(message) { }

        public DomainException(string message, Exception innerException) : base(message, innerException) { }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}