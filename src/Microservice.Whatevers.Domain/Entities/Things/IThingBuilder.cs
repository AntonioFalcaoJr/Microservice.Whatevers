using Microservice.Whatevers.Domain.Abstractions;

namespace Microservice.Whatevers.Domain.Entities.Things
{
    public interface IThingBuilder : IBuilder<Thing>
    {
        IThingBuilder WithName(string name);
        IThingBuilder WithType(string type);
        IThingBuilder WithValue(double value);
    }
}