using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Domain.Base
{
    public abstract class Builder<TBuilder, TEntity, TId> : IBuilder<TEntity>
        where TBuilder : Builder<TBuilder, TEntity, TId>
        where TEntity : EntityBase
        where TId : struct
    {
        private TId _id;

        public abstract TEntity Build();

        public TBuilder WithId(TId id)
        {
            _id = id;
            return (TBuilder) this;
        }
    }
}