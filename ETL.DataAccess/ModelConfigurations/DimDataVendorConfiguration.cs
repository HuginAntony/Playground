using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimDataVendorConfiguration : IEntityTypeConfiguration<DimDataVendor>
    {
        public void Configure(EntityTypeBuilder<DimDataVendor> modelBuilder)
        {
            modelBuilder.HasKey(e => e.VendorKey);

            modelBuilder.HasIndex(e => e.VendorId)
                        .HasName("IX_DimDataVendor")
                        .IsUnique();

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.VendorId)
                        .IsRequired()
                        .HasColumnName("VendorID")
                        .HasMaxLength(30);

            modelBuilder.Property(e => e.VendorName)
                        .IsRequired()
                        .HasMaxLength(50);
        }
    }
}