using System.Threading.Tasks;

namespace DDD.Core.NET5.Common.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        void Commit();

        Task CommitAsync();

        void Rollback();

        Task RollbackAsync();
    }
}