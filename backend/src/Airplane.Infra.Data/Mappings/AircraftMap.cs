using Airplane.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane.Infra.Data.Mappings
{
    public class AircraftMap : IEntityTypeConfiguration<Domain.Entities.Aircraft>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Aircraft> builder)
        {
            builder.HasIndex(c => c.Codigo)
                .IsUnique();

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(c => c.Modelo)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
