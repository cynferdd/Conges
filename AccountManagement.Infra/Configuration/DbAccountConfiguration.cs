using System;
using System.Collections.Immutable;
using AccountManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infra.Configuration
{
    public class DbAccountConfiguration : IEntityTypeConfiguration<DbAccount>
    {
        public void Configure(EntityTypeBuilder<DbAccount> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Name);
            builder.Property(a => a.ArchiveDate);
            builder.Property(a => a.AcquisitionStartDate);
            builder.Property(a => a.AcquisitionEndDate);
            builder.Property(a => a.ConsommationStartDate);
            builder.Property(a => a.ConsommationEndDate);
            builder.Property(a => a.AmountGained);
            builder.Property(a => a.Frequency)
                .HasConversion(f => f.ToString(), f => Enum.Parse<Frequency>(f));
        }
    }
}