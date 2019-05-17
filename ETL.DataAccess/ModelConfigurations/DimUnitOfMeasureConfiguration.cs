using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimUnitOfMeasureConfiguration : IEntityTypeConfiguration<DimUnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<DimUnitOfMeasure> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Uomkey);

            modelBuilder.Property(e => e.Uomkey).HasColumnName("UOMKey");

            modelBuilder.Property(e => e.Uomdescription)
                        .IsRequired()
                        .HasColumnName("UOMDescription")
                        .HasMaxLength(10);

            modelBuilder.HasOne(d => d.ConversionKeyNavigation)
                        .WithMany(p => p.InverseConversionKeyNavigation)
                        .HasForeignKey(d => d.ConversionKey)
                        .HasConstraintName("FK_DimUnitOfMeasure_DimUnitOfMeasure");
        }
    }
}