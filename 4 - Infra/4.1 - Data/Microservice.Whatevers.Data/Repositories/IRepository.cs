using System.Threading.Tasks;
using System;
using Microservice.Whatevers.Domain.Entities;
using System.Collections.Generic;
using System.Threading;

namespace Microservice.Whatevers.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        Task InsertAsync(T entity, CancellationToken cancellationToken);

        void Update(T entity);
        Task UpdateAsync(T entity, CancellationToken cancelletionToken);

        void Delete(Guid id);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        T Select(Guid id);
        Task<T> SelectAsync(Guid id, CancellationToken cancellationToken);

        IList<T> SelectAll();
        Task<IList<T>> SelectAllAsync(CancellationToken cancellationToken);
        
        bool Exists(Guid id);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}