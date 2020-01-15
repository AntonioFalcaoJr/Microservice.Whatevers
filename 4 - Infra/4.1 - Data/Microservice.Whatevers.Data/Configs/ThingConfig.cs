using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Data.Config
{
    public class ThingConfig : IEntityTypeConfiguration<Thing>
    {
        public void Configure(EntityTypeBuilder<Thing> builder)
        {
            builder.ToTable(nameof(Thing));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name");
            builder.Property(c => c.Value).IsRequired().HasColumnName("Value");
        }
    }
}