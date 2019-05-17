using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimProductSubcategoryConfiguration : IEntityTypeConfiguration<DimProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<DimProductSubcategory> modelBuilder)
        {
            modelBuilder.HasKey(e => e.ProductSubcategoryKey)
                        .HasName("PK_DimProductSubcategory_ProductSubcategoryKey");

            modelBuilder.HasIndex(e => e.ProductSubcategoryAlternateKey)
                        .HasName("AK_DimProductSubcategory_ProductSubcategoryAlternateKey")
                        .IsUnique();

            modelBuilder.Property(e => e.ProductSubcategoryAlternateKey).HasMaxLength(50);

            modelBuilder.Property(e => e.ProductSubcategoryName)
                        .IsRequired()
                        .HasMaxLength(50);

            modelBuilder.HasOne(d => d.ProductCategoryKeyNavigation)
                        .WithMany(p => p.DimProductSubcategory)
                        .HasForeignKey(d => d.ProductCategoryKey)
                        .HasConstraintName("FK_DimProductSubcategory_DimProductCategory");
        }
    }
}