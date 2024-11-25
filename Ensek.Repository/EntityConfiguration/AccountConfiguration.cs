using Ensek.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensek.Repository.EntityConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(u => u.AccountId);
            builder.Property(p=>p.FirstName).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(p => p.LastName).IsRequired().HasColumnType("nvarchar(100)");
            builder.HasMany(u => u.MeterReadings)
                .WithOne()
                .HasForeignKey(r => r.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
