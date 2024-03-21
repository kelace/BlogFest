using System.Data;

namespace BlogFest.Application.Abstract
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        Task CommitTransaction();
        Task BeginTransaction();
        Task RollbackTransaction();
        void Dispose();
    }
}
