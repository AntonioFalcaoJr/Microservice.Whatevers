using System;
namespace Microservice.Whatever.Domain.Entities
{
    public class Thing : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
    }
}



