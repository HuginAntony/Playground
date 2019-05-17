using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimProductConfiguration : IEntityTypeConfiguration<DimProduct>
    {
        public void Configure(EntityTypeBuilder<DimProduct> modelBuilder)
        {
            modelBuilder.HasKey(e => e.ProductKey)
                        .HasName("PK_DimProduct_ProductKey");

            modelBuilder.HasIndex(e => e.ProductAlternateKey)
                        .HasName("AK_DimProduct_ProductAlternateKey")
                        .IsUnique();

            modelBuilder.Property(e => e.Description)
                        .HasMaxLength(256)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.EndDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.IsBatchTrackingRequired).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.IsInventoryTrackingRequired).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.IsSaleable).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.ItemGroupCategory)
                        .HasMaxLength(64)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.ItemGroupDescription)
                        .HasMaxLength(64)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.ItemName)
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.ItemType)
                        .HasMaxLength(64)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.ProductAlternateKey)
                        .IsRequired()
                        .HasMaxLength(25);

            modelBuilder.Property(e => e.StartDate)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((1))");

            modelBuilder.Property(e => e.UnitofMeasure).HasMaxLength(10);
        }
    }
}