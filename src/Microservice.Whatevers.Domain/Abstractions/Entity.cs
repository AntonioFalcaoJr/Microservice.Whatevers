using System.Linq;
using Microservice.Whatevers.Domain.Abstractions.Notifications;

namespace Microservice.Whatevers.Domain.Abstractions
{
    public abstract class Entity<TId>
        where TId : struct
    {
        public INotification Notification { get; }

        protected Entity()
        {
            Notification = new Notification();
        }
        
        public TId Id { get; protected set; }
        public bool Valid => Notification?.Errors?.Any() == false;

        protected abstract void SetId(TId id);
    }
}