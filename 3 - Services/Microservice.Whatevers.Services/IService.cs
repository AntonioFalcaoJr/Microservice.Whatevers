using System.Threading;
using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;
using System.Threading.Tasks;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public interface IService<TEntity, TModel> 
        where TEntity : BaseEntity 
        where TModel : BaseModel
    {
        TEntity Save(TModel model);
        Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken);

        TEntity Edit(TModel model);
        Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken);

        void Delete(Guid id);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        TModel GetById(Guid id);
        Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        IList<TModel> GetAll();
        Task<IList<TModel>> GetAllAsync(CancellationToken cancellationToken);

        bool Exists(Guid id);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
    }
}