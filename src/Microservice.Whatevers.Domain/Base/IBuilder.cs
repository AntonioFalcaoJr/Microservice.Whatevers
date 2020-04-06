using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Domain.Base
{
    public interface IBuilder<out TEntity>
        where TEntity : EntityBase
    {
        TEntity Build();
    }
}