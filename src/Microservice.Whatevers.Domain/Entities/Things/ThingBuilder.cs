using System;
using Microservice.Whatevers.Domain.Abstractions.Builders;

namespace Microservice.Whatevers.Domain.Entities.Things
{
    public class ThingBuilder : Builder<ThingBuilder, Thing, Guid>, IThingBuilder
    {
        private string _name;
        private string _type;
        private double _value;

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

        public override Thing Build() => new Thing(Id, _name, _type, _value);
    }
}