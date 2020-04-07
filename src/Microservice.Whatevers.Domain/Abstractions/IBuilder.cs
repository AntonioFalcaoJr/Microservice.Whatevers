namespace Microservice.Whatevers.Domain.Abstractions
{
    public interface IBuilder<out TEntity>
        where TEntity : EntityBase
    {
        TEntity Build();
    }
}