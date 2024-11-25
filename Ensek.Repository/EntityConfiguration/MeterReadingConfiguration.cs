using Ensek.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensek.Repository.EntityConfiguration
{
    public class MeterReadingConfiguration : IEntityTypeConfiguration<MeterReading>
    {
        public void Configure(EntityTypeBuilder<MeterReading> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(p => p.MeterReadValue).IsRequired();
            builder.Property(p => p.MeterReadingDateTime).IsRequired();
            builder.Property(p => p.AccountId).IsRequired();

        }
    }
}
