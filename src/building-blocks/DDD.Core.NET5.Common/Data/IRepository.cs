using System;
using DDD.Core.NET5.Common.DomainObjects;

namespace DDD.Core.NET5.Common.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot { }
}