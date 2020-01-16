using Microservice.Whatevers.Services.Services;
using Microservice.Whatevers.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IWhateverService, WhateverService>();
            services.AddScoped<IWhateverValidator, WhateverValidator>();
            services.AddScoped<IThingValidator, ThingValidator>();
        }
    }
}