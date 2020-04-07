using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Whatever, WhateverModel>().ReverseMap();
            CreateMap<Thing, ThingModel>().ReverseMap();
        }
    }
}