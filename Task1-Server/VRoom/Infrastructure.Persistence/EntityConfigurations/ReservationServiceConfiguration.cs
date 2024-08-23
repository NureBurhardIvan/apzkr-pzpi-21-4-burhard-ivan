using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class ReservationServiceConfiguration : IEntityTypeConfiguration<ReservationService>
{
    public void Configure(EntityTypeBuilder<ReservationService> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.ReservationId).IsRequired();
        builder.Property(r => r.ServiceId).IsRequired();
    }
}