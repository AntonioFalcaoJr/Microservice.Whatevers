using Microservice.Whatevers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Data.Contexts
{
    public class WhateverContext : DbContext
    {
        public DbSet<Whatever> Whatevers { get; set; }
        public DbSet<Thing> Things { get; set; }

        public WhateverContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseInMemoryDatabase("WhateverDb");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WhateverContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}