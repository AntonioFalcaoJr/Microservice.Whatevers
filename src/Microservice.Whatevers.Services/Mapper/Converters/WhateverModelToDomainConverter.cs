using System;
using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Mapper.Converters
{
    public class WhateverModelToDomainConverter : ITypeConverter<WhateverModel, Whatever>
    {
        public Whatever Convert(WhateverModel source, Whatever destination, ResolutionContext context) =>
            new WhateverBuilder()
               .WithId(source.Id ?? Guid.NewGuid())
               .WithName(source.Name)
               .WithTime(source.Time)
               .WithType(source.Type)
               .Build();
    }
}