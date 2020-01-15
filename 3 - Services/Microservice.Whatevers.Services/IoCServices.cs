using Microservice.Whatevers.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Services
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IWhateverService, WhateverService>();
        }
    }
}