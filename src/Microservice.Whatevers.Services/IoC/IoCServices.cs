using AutoMapper;
using Microservice.Whatevers.Services.Clients;
using Microservice.Whatevers.Services.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services.IoC
{
    public static class IocServices
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ModelToDomainProfile));

        public static IServiceCollection AddServices(this IServiceCollection services)
            => services
               .AddScoped<IWhateverService, WhateverService>()
               .AddScoped<IGoogleService, GoogleService>()
               .AddScoped<IGoogleClient, GoogleClient>();
    }
}