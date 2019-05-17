using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimPromotionConfiguration : IEntityTypeConfiguration<DimPromotion>
    {
        public void Configure(EntityTypeBuilder<DimPromotion> modelBuilder)
        {
            modelBuilder.HasKey(e => e.PromotionKey)
                        .HasName("PK_DimPromotion_PromotionKey");

            modelBuilder.HasIndex(e => e.PromotionAlternateKey)
                        .HasName("AK_DimPromotion_PromotionAlternateKey")
                        .IsUnique();

            modelBuilder.Property(e => e.EndDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.EnglishPromotionCategory).HasMaxLength(50);

            modelBuilder.Property(e => e.EnglishPromotionName).HasMaxLength(255);

            modelBuilder.Property(e => e.EnglishPromotionType).HasMaxLength(50);

            modelBuilder.Property(e => e.StartDate).HasColumnType("datetime");
        }
    }
}