using System;

namespace Microservice.Whatever.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}