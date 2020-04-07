namespace Microservice.Whatevers.Domain.Abstractions
{
    public interface IBuilder<out TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        TEntity Build();
    }
}