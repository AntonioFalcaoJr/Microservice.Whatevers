using AutoMapper;
using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Mapper
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<Whatever, WhateverModel>();
            CreateMap<Thing, ThingModel>();
        }
    }
}