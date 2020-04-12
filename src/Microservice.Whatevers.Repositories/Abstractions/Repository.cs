using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Repositories.Abstractions
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(TId id)
        {
            _dbSet.Remove(SelectById(id));
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            _dbSet.Remove(await SelectByIdAsync(id, cancellationToken).ConfigureAwait(false));
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual bool Exists(TId id) => _dbSet.AsNoTracking().Any(x => Equals(x.Id, id));

        public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().AnyAsync(x => Equals(x.Id, id), cancellationToken);

        public virtual void Insert(TEntity entity)
        {
            if (Exists(entity.Id)) return;

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken).ConfigureAwait(false)) return;

            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual TEntity SelectById(TId id) => _dbSet.Find(id);

        public virtual async Task<TEntity> SelectByIdAsync(TId id, CancellationToken cancellationToken) =>
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
            if (await ExistsAsync(entity.Id, cancellationToken).ConfigureAwait(false) == false) return;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}