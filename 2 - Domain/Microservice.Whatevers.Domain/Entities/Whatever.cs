using System;
using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.Entities
{
    public class Whatever : BaseEntity
    {
        public string Name { get; set; }
        public IList<Thing> Things { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
    }
}