using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Repositories.IoC
{
    public static class IoCRepositories
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<WhateverContext>(dbContextOptions
                => dbContextOptions.UseLazyLoadingProxies()
                   .UseSqlite(connectionString, sqliteOptions
                        => sqliteOptions.MigrationsAssembly(typeof(WhateverContext).Assembly.GetName().Name)));

        public static IServiceCollection AddRepository(this IServiceCollection services)
            => services.AddScoped<IWhateverRepository, WhateverRepository>();
    }
}