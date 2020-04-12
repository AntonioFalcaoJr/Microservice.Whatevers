using Microservice.Whatevers.Domain.Entities.Things;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Repositories.Contexts
{
    public class WhateverContext : DbContext
    {
        public WhateverContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Thing> Things { get; set; }
        public DbSet<Whatever> Whatevers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WhateverContext).Assembly);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}