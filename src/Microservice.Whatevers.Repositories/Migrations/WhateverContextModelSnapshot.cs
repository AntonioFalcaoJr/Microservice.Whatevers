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

                b.Property<Guid?>("WhateverId")
                   .HasColumnType("TEXT");

                b.HasKey("Id");

                b.HasIndex("WhateverId");

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
                        Id = new Guid("c267dc0e-8829-49a9-9d1c-54e1488298f4"),
                        Name = "Whatever",
                        Time = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Type = "Some type"
                    },
                    new
                    {
                        Id = new Guid("e43bf835-dac0-4805-a29b-4117d3cf06ea"),
                        Name = "Whatever",
                        Time = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                        Type = "Another type"
                    },
                    new
                    {
                        Id = new Guid("532b162e-f5a4-4595-a8a8-cc9e4270a05f"),
                        Name = "Whatever",
                        Time = new DateTime(2020, 4, 18, 0, 21, 46, 898, DateTimeKind.Local).AddTicks(5592),
                        Type = "More another type"
                    },
                    new
                    {
                        Id = new Guid("9288ccdf-bd54-4a45-82c7-1b0351baf2f5"),
                        Name = "Whatever",
                        Time = new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Local),
                        Type = "Once more another type"
                    });
            });

            modelBuilder.Entity("Microservice.Whatevers.Domain.Entities.Things.Thing", b =>
            {
                b.HasOne("Microservice.Whatevers.Domain.Entities.Whatevers.Whatever", null)
                   .WithMany("Things")
                   .HasForeignKey("WhateverId");
            });
#pragma warning restore 612, 618
        }
    }
}