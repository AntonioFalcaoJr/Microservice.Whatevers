using System;

namespace Microservice.Whatevers.Services.Models
{
    public abstract class BaseModel : BaseError
    {
        public virtual Guid? Id { get; set; }
    }
}