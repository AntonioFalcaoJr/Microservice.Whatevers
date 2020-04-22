using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Repositories.IoC
{
    public static class IoCRepositories
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<WhateverContext>(dbContextOptions
                => dbContextOptions.UseLazyLoadingProxies()
                   .UseSqlite(configuration.GetConnectionString("DefaultConnection"), sqliteOptions
                        => sqliteOptions.MigrationsAssembly(typeof(WhateverContext).Assembly.GetName().Name)));

        public static IServiceCollection AddRepository(this IServiceCollection services)
            => services.AddScoped<IWhateverRepository, WhateverRepository>();
    }
}