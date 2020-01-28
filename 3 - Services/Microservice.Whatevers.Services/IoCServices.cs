using FluentValidation;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IService<Whatever>, WhateverService>();
            services.AddScoped<IValidator<Whatever>, WhateverValidator>();
            services.AddScoped<IValidator<Thing>, ThingValidator>();
        }
    }
}