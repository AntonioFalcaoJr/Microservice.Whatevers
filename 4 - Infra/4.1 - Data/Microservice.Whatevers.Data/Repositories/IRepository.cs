using Microservice.Whatevers.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace Microservice.Whatevers.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancelletionToken);

        void Delete(Guid id);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        TEntity SelectById(Guid id);
        Task<TEntity> SelectByIdAsync(Guid id, CancellationToken cancellationToken);

        IQueryable<TEntity> SelectAll();
        
        bool Exists(Guid id);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}