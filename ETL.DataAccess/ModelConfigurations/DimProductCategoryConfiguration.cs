using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimProductCategoryConfiguration : IEntityTypeConfiguration<DimProductCategory>
    {
        public void Configure(EntityTypeBuilder<DimProductCategory> modelBuilder)
        {
            modelBuilder.HasKey(e => e.ProductCategoryKey)
                        .HasName("PK_DimProductCategory_ProductCategoryKey");

            modelBuilder.HasIndex(e => e.ProductCategoryAlternateKey)
                        .HasName("AK_DimProductCategory_ProductCategoryAlternateKey")
                        .IsUnique();

            modelBuilder.Property(e => e.ProductCategoryAlternateKey)
                        .IsRequired()
                        .HasMaxLength(50);

            modelBuilder.Property(e => e.ProductCategoryName)
                        .IsRequired()
                        .HasMaxLength(50);
        }
    }
}