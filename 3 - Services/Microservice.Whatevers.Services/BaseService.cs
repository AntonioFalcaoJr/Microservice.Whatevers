using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Data.Repositories;

namespace Microservice.Whatevers.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id inválido");

            _repository.Delete(id);
        }

        public TEntity Edit(TEntity entity) 
        {
            _repository.Update(entity);
            return entity;
        }

        public IList<TEntity> Get() => _repository.SelectAll();

        public TEntity GetById(Guid id)
        {
            return id == Guid.Empty
                ? throw new ArgumentException("Id inválido")
                : _repository.Select(id);
        }

        public TEntity Save(TEntity entity)
        {
            _repository.Insert(entity);
            return entity;
        }
    }
}
