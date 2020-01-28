using System;

namespace Microservice.Whatevers.Services.Models
{
    public class ThingModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
    }
}