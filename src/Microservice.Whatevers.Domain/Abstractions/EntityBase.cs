using System.Linq;
using Microservice.Whatevers.Domain.Abstractions.Notifications;

namespace Microservice.Whatevers.Domain.Abstractions
{
    public abstract class EntityBase<TId>
        where TId : struct
    {
        public readonly INotification Notification = new Notification();
        public TId Id { get; protected set; }
        
        public bool IsValid() => Notification.GetErrors()?.Any() == false;
        
        protected abstract void SetId(TId id);
    }
}