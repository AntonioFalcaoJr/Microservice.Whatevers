using Microservice.Whatevers.Data.Contexts;
using Microservice.Whatevers.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Data
{
    public class IoCData
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<WhateverContext>(options =>
                    options.UseInMemoryDatabase("WhateverDb").UseLazyLoadingProxies());

            services.AddScoped<IWhateverRepository, WhateverRepository>();
        }
    }
}