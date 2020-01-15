using System.Collections.Generic;
using Microservice.Whatevers.Data.Repository;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Data.Context;

namespace Microservice.Whatevers.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly WhateverContext _whateverContext = new WhateverContext();

        public void Delete(int id)
        {
        }

        public void Insert(T entity)
        {
            _whateverContext.Set<T>().Add(entity);
            _whateverContext.SaveChanges();
        }

        public T Select(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<T> SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}