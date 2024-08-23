using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class IoTDataConfiguration: IEntityTypeConfiguration<IoTData>
{
    public void Configure(EntityTypeBuilder<IoTData> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Timestamp).IsRequired();
        builder.Property(i => i.Temperature).IsRequired();
        builder.Property(i => i.Humidity).IsRequired();
    }
}