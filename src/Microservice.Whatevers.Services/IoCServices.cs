using FluentValidation;
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
            services.AddTransient<IValidator<WhateverModel>, WhateverModelValidator>();
            services.AddTransient<IValidator<ThingModel>, ThingModelValidator>();
        }
    }
}