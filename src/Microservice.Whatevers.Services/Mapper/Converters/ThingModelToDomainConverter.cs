using System;
using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Mapper.Converters
{
    public class ThingModelToDomainConverter : ITypeConverter<ThingModel, Thing>
    {
        public Thing Convert(ThingModel source, Thing destination, ResolutionContext context) =>
            new ThingBuilder()
               .WithId(source.Id ?? Guid.NewGuid())
               .WithName(source.Name)
               .WithType(source.Type)
               .WithValue(source.Value)
               .Build();
    }
}