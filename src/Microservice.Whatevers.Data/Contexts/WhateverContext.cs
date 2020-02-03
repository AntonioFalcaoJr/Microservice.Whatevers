using Microservice.Whatevers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Data.Contexts
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
            base.OnModelCreating(modelBuilder);
        }
    }
}