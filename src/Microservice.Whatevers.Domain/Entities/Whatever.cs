using System;
using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.Entities
{
    public class Whatever : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Thing> Things { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
    }
}