using System;
using Microservice.Whatevers.Domain.Entities;
using System.Collections.Generic;

namespace Microservice.Whatevers.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T Select(Guid id);
        IList<T> SelectAll();
    }
}