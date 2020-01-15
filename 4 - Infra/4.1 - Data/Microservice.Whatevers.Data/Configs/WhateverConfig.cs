using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Data.Config
{
    public class WhateverConfig : IEntityTypeConfiguration<Whatever>
    {
        public void Configure(EntityTypeBuilder<Whatever> builder)
        {
            builder.ToTable(nameof(Whatever));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name");
            builder.Property(c => c.Time);
            builder.HasMany(c => c.Things);
        }
    }
}