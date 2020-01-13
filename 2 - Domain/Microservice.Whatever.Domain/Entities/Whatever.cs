using System;
using System.Collections.Generic;

namespace Microservice.Whatever.Domain.Entities
{
    public class Whatever : BaseEntity
    {
        public string Name { get; set; }
        public string  Type { get; set; }
        public DateTime Time { get; set; }
        public IList<Thing> Things { get; set; }
    }
}