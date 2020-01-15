using System;
using FluentValidation;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Data.Repositories;

namespace Microservice.Whatevers.Services.Services
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

        public TEntity Edit<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());

            _repository.Update(entity);
            return entity;
        }

        public IList<TEntity> Get() => _repository.SelectAll();

        public TEntity GetById(Guid id)
        {
            return id != Guid.Empty
                ? _repository.Select(id)
                : throw new ArgumentException("Id inválido");

        }

        public TEntity Save<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());

            _repository.Insert(entity);
            return entity;
        }

        private void Validate(TEntity entity, AbstractValidator<TEntity> validator)
        {
            if (entity is null)
                throw new Exception("Entidade não encontrada/informada");

            validator.ValidateAndThrow(entity);
        }
    }
}