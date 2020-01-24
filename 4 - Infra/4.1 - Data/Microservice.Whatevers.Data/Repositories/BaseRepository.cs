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
        private readonly DbSet<T> _dbSet;

        protected BaseRepository(IWhateverContext whateverContext)
        {
            _context = whateverContext;
            _dbSet = whateverContext.Set<T>();
        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(SelectById(id));
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            _dbSet.Remove(await SelectByIdAsync(id, cancellationToken));
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public bool Exists(Guid id) => 
            _dbSet.AsNoTracking().Any(x => x.Id == id);

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) => 
            await _dbSet.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);

        public void Insert(T entity)
        {
            if (Exists(entity.Id)) return;

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task InsertAsync(T entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken)) return;
            
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public T SelectById(Guid id) => 
            _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public async Task<T> SelectByIdAsync(Guid id, CancellationToken cancellationToken) => 
            await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public IList<T> SelectAll() => 
            _dbSet.AsNoTracking().ToList();

        public async Task<IList<T>> SelectAllAsync(CancellationToken cancellationToken) => 
            await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

        public void Update(T entity)
        {
            if (!Exists(entity.Id)) return;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            if (!await ExistsAsync(entity.Id, cancellationToken)) return;
            
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(true, cancellationToken);
        }
    }
}