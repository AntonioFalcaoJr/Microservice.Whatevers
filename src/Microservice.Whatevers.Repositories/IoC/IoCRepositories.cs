using System.Reflection;
using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Whatevers.Repositories.IoC
{
    public class IoCRepositories
    {
        public static void Register(IServiceCollection services, string migrationsAssembly)
        {
            services.AddDbContext<WhateverContext>(options =>
                options.UseSqlite($"Data Source={ApplicationEnvironment.ApplicationBasePath}Whatever.db", 
                    builder => builder.MigrationsAssembly(migrationsAssembly)));

            services.AddScoped<IWhateverRepository, WhateverRepository>();
        }
    }
}