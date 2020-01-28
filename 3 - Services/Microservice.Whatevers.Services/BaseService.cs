using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Data.Repositories;
using System.Threading.Tasks;
using System.Threading;

namespace Microservice.Whatevers.Services
{
    public abstract class BaseService<TEntity, TModel> : IService<TEntity> 
        where TEntity : BaseEntity 
        where TModel: class
    {
        private readonly IRepository<TEntity> _repository;

        protected BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id inválido");

            _repository.Delete(id);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id inválido");

            await _repository.DeleteAsync(id, cancellationToken);
        }

        public TEntity Edit(TEntity entity)
        {
            _repository.Update(entity);
            return entity;
        }

        public async Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
            return entity;
        }

        public bool Exists(Guid id) => _repository.Exists(id);

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) => 
            await _repository.ExistsAsync(id, cancellationToken);

        public IEnumerable<TEntity> GetAll() => _repository.SelectAll();

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) => 
            await _repository.SelectAllAsync(cancellationToken);

        public TEntity GetById(Guid id) => 
            id == Guid.Empty
                ? throw new ArgumentException("Id inválido")
                : _repository.SelectById(id);

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken) => 
            id == Guid.Empty
                ? throw new ArgumentException("Id inválido")
                : await _repository.SelectByIdAsync(id, cancellationToken);

        public TEntity Save(TEntity entity)
        {
            _repository.Insert(entity);
            return entity;
        }

        public async Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(entity, cancellationToken);
            return entity;
        }
    }
}
