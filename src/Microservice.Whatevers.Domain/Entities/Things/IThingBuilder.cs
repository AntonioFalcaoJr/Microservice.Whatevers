using System;
using Microservice.Whatevers.Domain.Abstractions.Builders;

namespace Microservice.Whatevers.Domain.Entities.Things
{
    public interface IThingBuilder : IBuilder<Thing, Guid>
    {
        IThingBuilder WithName(string name);
        IThingBuilder WithType(string type);
        IThingBuilder WithValue(double value);
    }
}