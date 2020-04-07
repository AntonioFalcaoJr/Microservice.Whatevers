using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Repositories
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