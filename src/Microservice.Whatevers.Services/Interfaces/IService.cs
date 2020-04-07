using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Interfaces
{
    public interface IService<TEntity, TModel, in TId>
        where TEntity : EntityBase<TId>
        where TModel : BaseModel
        where TId : struct
    {
        void Delete(TId id);
        Task DeleteAsync(TId id, CancellationToken cancellationToken);

        TModel Edit(TModel model);
        Task<TModel> EditAsync(TModel model, CancellationToken cancellationToken);

        bool Exists(TId id);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken);

        IList<TModel> GetAll();
        Task<IList<TModel>> GetAllAsync(CancellationToken cancellationToken);

        TModel GetById(TId id);
        Task<TModel> GetByIdAsync(TId id, CancellationToken cancellationToken);

        TModel Save(TModel model);
        Task<TModel> SaveAsync(TModel model, CancellationToken cancellationToken);
    }
}