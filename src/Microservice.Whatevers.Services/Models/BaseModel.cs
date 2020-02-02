using System;

namespace Microservice.Whatevers.Services.Models
{
    public abstract class BaseModel
    {
        public virtual Guid? Id { get; set; }
    }
}