using System;
using Microservice.Whatevers.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Microservice.Whatevers.Repositories.Migrations
{
    [DbContext(typeof(WhateverContext))]
    internal class WhateverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
               .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Microservice.Whatevers.Domain.Entities.Things.Thing", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("TEXT");

                b.Property<string>("Name")
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("TEXT");

                b.Property<string>("Type")
                   .HasColumnType("TEXT");

                b.Property<double>("Value")
                   .HasColumnType("REAL");

                b.HasKey("Id");

                b.ToTable("Thing");
            });

            modelBuilder.Entity("Microservice.Whatevers.Domain.Entities.Whatevers.Whatever", b =>
            {
                b.Property<Guid>("Id")
                   .ValueGeneratedOnAdd()
                   .HasColumnType("TEXT");

                b.Property<string>("Name")
                   .IsRequired()
                   .HasColumnType("TEXT");

                b.Property<DateTime>("Time")
                   .HasColumnType("TEXT");

                b.Property<string>("Type")
                   .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Whatever");

                b.HasData(new
                    {
                        Id = new Guid("491f4d02-7361-4740-b251-6917105eaf94"),
                        Name = "Whatever",
                        Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Type = "Some type"
                    },
                    new
                    {
                        Id = new Guid("f45a9688-0dda-4e57-b1d2-b8d6f59bf892"),
                        Name = "Whatever",
                        Time = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                        Type = "Another type"
                    },
                    new
                    {
                        Id = new Guid("92fe8164-1e26-407a-aeee-6d6297416666"),
                        Name = "Whatever",
                        Time = new DateTime(2020, 4, 12, 14, 49, 47, 417, DateTimeKind.Local).AddTicks(9161),
                        Type = "More another type"
                    },
                    new
                    {
                        Id = new Guid("10b38c17-0e76-427a-84a6-f2c6c514858c"),
                        Name = "Whatever",
                        Time = new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Local),
                        Type = "Once more type"
                    });
            });
#pragma warning restore 612, 618
        }
    }
}