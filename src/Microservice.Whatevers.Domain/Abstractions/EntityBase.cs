using System;

namespace Microservice.Whatevers.Domain.Abstractions
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; }
    }
}