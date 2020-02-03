using AutoMapper;
using Microservice.Whatevers.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToModelMappingProfile));
            services.AddScoped<IWhateverService, WhateverService>();
        }
    }
}