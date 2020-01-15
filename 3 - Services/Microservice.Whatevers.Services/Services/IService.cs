using System;
using FluentValidation;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Services.Services
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        TEntity Save<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        TEntity Edit<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
        void Delete(Guid id);
        TEntity GetById(Guid id);
        IList<TEntity> Get();
    }
}