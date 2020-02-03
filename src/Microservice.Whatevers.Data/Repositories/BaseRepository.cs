using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(Guid id)
        {
            _dbSet.Remove(SelectById(id));
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            _dbSet.Remove(await SelectByIdAsync(id, cancellationToken));
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual bool Exists(Guid id) => _dbSet.AsNoTracking().Any(x => x.Id == id);

        public virtual async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().AnyAsync(x => x.Id == id, cancellationToken);

        public virtual void Insert(TEntity entity)
        {
            if (Exists(entity.Id)) return;

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken)) return;

            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual TEntity SelectById(Guid id) => _dbSet.Find(id);

        public virtual async Task<TEntity> SelectByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _dbSet.FindAsync(new object[] {id}, cancellationToken);

        public IQueryable<TEntity> SelectAll() => _dbSet.AsNoTracking();

        public void Update(TEntity entity)
        {
            if (!Exists(entity.Id)) return;

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (!await ExistsAsync(entity.Id, cancellationToken)) return;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}