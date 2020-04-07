using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Domain.Entities.Things;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public class Whatever : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Thing> Things { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
    }
}