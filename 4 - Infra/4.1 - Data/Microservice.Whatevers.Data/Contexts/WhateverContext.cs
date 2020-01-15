using Microsoft.EntityFrameworkCore;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Data.Contexts;

namespace Microservice.Whatevers.Data.Context
{
    public class WhateverContext : DbContext, IWhateverContext
    {
        public DbSet<Whatever> Whatevers { get; set; }
        public DbSet<Thing> Things { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase(databaseName: "WhateverDb");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Whatever>(new WhateverConfig().Configure);
            // modelBuilder.Entity<Thing>(new ThingConfig().Configure);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WhateverContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}