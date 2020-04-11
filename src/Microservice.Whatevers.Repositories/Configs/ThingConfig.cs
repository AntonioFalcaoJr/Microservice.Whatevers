using Microservice.Whatevers.Domain.Entities.Things;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Whatevers.Repositories.Configs
{
    public class ThingConfig : IEntityTypeConfiguration<Thing>
    {
        public void Configure(EntityTypeBuilder<Thing> builder)
        {
            builder
               .ToTable(nameof(Thing));
            
            builder
               .HasKey(c => c.Id);

            builder
               .Property(c => c.Name)
               .HasColumnName("Name")
               .IsRequired();
            
            builder
               .Property(c => c.Value)
               .IsRequired();
        }
    }
}