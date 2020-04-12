using System;
using System.Collections.Generic;
using System.Data;
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
            Seed(modelBuilder);
            //base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var whateverBuilder = new WhateverBuilder();
            
            modelBuilder.Entity<Whatever>().HasData(new List<Whatever>
            {
                whateverBuilder
                   .WithId(Guid.NewGuid())
                   .WithName(nameof(Whatever))
                   .WithTime(new DateTime())
                   .WithType("Some type")
                   .Build(),
                
                whateverBuilder
                   .WithId(Guid.NewGuid())
                   .WithName(nameof(Whatever))
                   .WithTime(DateTime.MaxValue)
                   .WithType("Another type")
                   .Build(),
                
                whateverBuilder
                   .WithId(Guid.NewGuid())
                   .WithName(nameof(Whatever))
                   .WithTime(DateTime.Now)
                   .WithType("More another type")
                   .Build(),
                
                whateverBuilder
                   .WithId(Guid.NewGuid())
                   .WithName(nameof(Whatever))
                   .WithTime(DateTime.Today)
                   .WithType("Once more type")
                   .Build()
            });
        }
    }
}