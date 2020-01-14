using Microsoft.EntityFrameworkCore;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Data.Config;

namespace Microservice.Whatevers.Data.Context
{
    public class WhateverContext : DbContext
    {
        public DbSet<Whatever> Whatevers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase(databaseName: "WhateverDb");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Whatever>(new WhateverConfig().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }
}