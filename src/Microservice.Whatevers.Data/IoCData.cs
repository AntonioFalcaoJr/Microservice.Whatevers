using Microservice.Whatevers.Data.Contexts;
using Microservice.Whatevers.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Data
{
    public class IoCData
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IWhateverContext, WhateverContext>();
            services.AddScoped<IWhateverRepository, WhateverRepository>();
        }
    }
}