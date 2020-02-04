using FluentValidation.AspNetCore;
using Microservice.Whatevers.Data;
using Microservice.Whatevers.Services;
using Microservice.Whatevers.Services.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservice.Whatevers.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning();

            services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false)
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<WhateverModelValidator>());

            IocServices.Register(services);
            IoCData.Register(services);
        }
    }
}