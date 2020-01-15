using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microservice.Whatevers.Data.Contexts;

namespace Microservice.Whatevers.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IWhateverContext _context;

        public BaseRepository(IWhateverContext whateverContext)
        {
            _context = whateverContext;
        }

        public void Delete(Guid id)
        {
            _context.Set<T>().Remove(Select(id));
            _context.SaveChanges();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public T Select(Guid id) => _context.Set<T>().Find(id);

        public IList<T> SelectAll() => _context.Set<T>().ToList();

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}