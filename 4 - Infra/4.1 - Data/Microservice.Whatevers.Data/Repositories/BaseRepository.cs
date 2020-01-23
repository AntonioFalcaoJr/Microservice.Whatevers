using System.Threading;
using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microservice.Whatevers.Data.Contexts;
using System.Threading.Tasks;

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

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(Select(id));
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public bool Exists(Guid id) => Select(id) is null ? default : true;

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) => 
         (await SelectAsync(id, cancellationToken)) is null ? default : true;

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task InsertAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public T Select(Guid id) => _context.Set<T>().Find(id);

        public async Task<T> SelectAsync(Guid id, CancellationToken cancellationToken) =>
            await _context.Set<T>().FindAsync(id, cancellationToken);

        public IList<T> SelectAll() => _context.Set<T>().ToList();

        public async Task<IList<T>> SelectAllAsync(CancellationToken cancellationToken) =>
            await _context.Set<T>().ToListAsync();


        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(true, cancellationToken);
        }
    }
}