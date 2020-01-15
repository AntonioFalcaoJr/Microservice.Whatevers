using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Microservice.Whatevers.Data.Contexts
{
    public interface IDbContext 
    {
          DbSet<TEntity> Set<TEntity>() where TEntity : class;
          EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
          int SaveChanges();
    }
}