using AutoMapper;
using FluentValidation;
using Microservice.Whatevers.Services.Mapper;
using Microservice.Whatevers.Services.Models;
using Microservice.Whatevers.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IValidator<WhateverModel>, WhateverModelValidator>();
            services.AddTransient<IValidator<ThingModel>, ThingModelValidator>();
            
            services.AddAutoMapper(typeof(DomainToModelMappingProfile), typeof(ModelToDomainMappingProfile));
            
            services.AddScoped<IWhateverService, WhateverService>();
        }
    }
}