using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Repositories.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var whateverBuilder = new WhateverBuilder();

            modelBuilder
               .Entity<Whatever>()
               .HasData(new List<Whatever>
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
                       .WithType("Once more another type")
                       .Build()
                });
        }
    }
}