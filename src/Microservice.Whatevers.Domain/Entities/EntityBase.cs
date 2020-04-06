using System;

namespace Microservice.Whatevers.Domain.Entities
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; }
    }
}