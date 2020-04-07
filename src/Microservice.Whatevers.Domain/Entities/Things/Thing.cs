using Microservice.Whatevers.Domain.Abstractions;

namespace Microservice.Whatevers.Domain.Entities.Things
{
    public class Thing : EntityBase
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public double Value { get; private set; }

        public Thing(string name, string type, double value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public void SetName(string name)
        {
            Name = name;
        }
        
        public void SetType(string type)
        {
            Type = type;
        }
        
        public void SetValue(double value)
        {
            Value = value;
        }
        
    }
}