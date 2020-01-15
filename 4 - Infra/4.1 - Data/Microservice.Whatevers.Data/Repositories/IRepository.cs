using Microservice.Whatevers.Domain.Entities;
using System.Collections.Generic;

namespace Microservice.Whatevers.Data.Repository
{
    public interface IRepository<T> 
    where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        T Select(int id);
        IList<T> SelectAll();
    }
}