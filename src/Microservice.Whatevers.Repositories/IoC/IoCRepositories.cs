using System;
using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Repositories.IoC
{
    public static class IoCRepositories
    {
        private static readonly RepositoriesOptions RepositoriesOptions = new RepositoriesOptions();

        public static IServiceCollection AddDbContext(this IServiceCollection services, Action<RepositoriesOptions> options)
        {
            options.Invoke(RepositoriesOptions);

            return services.AddDbContext<WhateverContext>(dbContextOptions
                => dbContextOptions.UseLazyLoadingProxies()
                   .UseSqlite(RepositoriesOptions.ConnectionString, sqliteOptions
                        => sqliteOptions.MigrationsAssembly(typeof(WhateverContext).Assembly.GetName().Name)));
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
            => services.AddScoped<IWhateverRepository, WhateverRepository>();
    }
}