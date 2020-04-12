using AutoMapper;
using Microservice.Whatevers.Services.Abstractions;
using Microservice.Whatevers.Services.Clients;
using Microservice.Whatevers.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services.IoC
{
    public static class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IWhateverService, WhateverService>();
            services.AddScoped<IGoogleClientService, GoogleClientService>();
            services.AddScoped<IGoogleClient, GoogleClient>();
        }
    }
}