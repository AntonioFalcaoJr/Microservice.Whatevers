using AutoMapper;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Mapper
{
    public class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            CreateMap<WhateverModel, Whatever>();
            CreateMap<ThingModel, Thing>();
        }
    }
}