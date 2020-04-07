using Microservice.Whatevers.Domain.Abstractions.Notifications;

namespace Microservice.Whatevers.Domain.Abstractions
{
    public abstract class EntityBase<TId> : Notification<EntityBase<TId>>
        where TId : struct
    {
        public TId Id { get; protected set; }
        public abstract void SetId(TId id);
    }
}