using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public interface IService<TEntity, TModel>
        where TEntity : EntityBase
        where TModel : BaseModel
    {
        void Delete(Guid id);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        TModel Edit(TModel model);
        Task<TModel> EditAsync(TModel model, CancellationToken cancellationToken);

        bool Exists(Guid id);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

        IList<TModel> GetAll();
        Task<IList<TModel>> GetAllAsync(CancellationToken cancellationToken);

        TModel GetById(Guid id);
        Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        TModel Save(TModel model);
        Task<TModel> SaveAsync(TModel model, CancellationToken cancellationToken);
    }
}