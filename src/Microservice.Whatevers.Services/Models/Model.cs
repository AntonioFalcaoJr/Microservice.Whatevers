using System;

namespace Microservice.Whatevers.Services.Models
{
    public abstract class Model
    {
        public virtual Guid? Id { get; set; }
    }
}