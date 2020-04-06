using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Domain.Base
{
    public abstract class Builder<TEntity> : IBuilder<TEntity> 
        where TEntity : EntityBase
    {
        public abstract TEntity Build(); 
    }
}