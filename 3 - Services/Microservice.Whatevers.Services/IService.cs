using System.Threading;
using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;
using System.Threading.Tasks;

namespace Microservice.Whatevers.Services
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        TEntity Save(TEntity entity);
        Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken);

        TEntity Edit(TEntity entity);
        Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken);

        void Delete(Guid id);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        bool Exists(Guid id);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}