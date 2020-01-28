using FluentValidation;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services.Models;
using Microservice.Whatevers.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IWhateverService, WhateverService>();
            services.AddScoped<IValidator<WhateverModel>, WhateverModelValidator>();
            services.AddScoped<IValidator<ThingModel>, ThingModelValidator>();
        }
    }
}