using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Services
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        TEntity Save(TEntity entity);
        TEntity Edit(TEntity entity);
        void Delete(Guid id);
        TEntity GetById(Guid id);
        IList<TEntity> GetAll();
    }
}