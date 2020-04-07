namespace Microservice.Whatevers.Domain.Entities.Things
{
    public class ThingBuilder : IThingBuilder
    {
        private string _name;
        private string _type;
        private double _value;
        
        public Thing Build() => throw new System.NotImplementedException();

        public IThingBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IThingBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public IThingBuilder WithValue(double value)
        {
            _value = value;
            return this;
        }
    }
}