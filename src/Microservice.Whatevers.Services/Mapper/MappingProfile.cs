using AutoMapper;
using Microservice.Whatevers.Domain.Entities;
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