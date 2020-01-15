using System.Collections.Generic;
using Microservice.Whatevers.Data.Repository;
using Microservice.Whatevers.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microservice.Whatevers.Data.Contexts;

namespace Microservice.Whatevers.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IWhateverContext _whateverContext;

        public BaseRepository(IWhateverContext whateverContext)
        {
            _whateverContext = whateverContext;
        }

        public void Delete(int id)
        {
            _whateverContext.Set<T>().Remove(Select(id));
            _whateverContext.SaveChanges();
        }

        public void Insert(T entity)
        {
            _whateverContext.Set<T>().Add(entity);
            _whateverContext.SaveChanges();
        }

        public T Select(int id) => _whateverContext.Set<T>().Find(id);

        public IList<T> SelectAll() => _whateverContext.Set<T>().ToList();

        public void Update(T entity)
        {
            _whateverContext.Entry(entity).State = EntityState.Modified;
            _whateverContext.SaveChanges();
        }
    }
}