using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Services.Mapper.Converters;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Mapper
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<WhateverModel, Whatever>()
               .ConvertUsing<WhateverModelToDomainConverter>();

            CreateMap<ThingModel, Thing>()
               .ConvertUsing<ThingModelToDomainConverter>();
        }
    }
}