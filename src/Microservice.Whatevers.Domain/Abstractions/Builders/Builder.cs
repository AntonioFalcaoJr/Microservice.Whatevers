namespace Microservice.Whatevers.Domain.Abstractions.Builders
{
    public abstract class Builder<TBuilder, TEntity, TId> : IBuilder<TEntity, TId>
        where TBuilder : Builder<TBuilder, TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        protected TId Id;

        public abstract TEntity Build();

        public TBuilder WithId(TId id)
        {
            Id = id;
            return (TBuilder) this;
        }
    }
}