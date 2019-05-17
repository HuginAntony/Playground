using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimCurrencyConfiguration : IEntityTypeConfiguration<DimCurrency>
    {
        public void Configure(EntityTypeBuilder<DimCurrency> modelBuilder)
        {
            modelBuilder.HasKey(e => e.CurrencyKey)
                        .HasName("PK_DimCurrency_CurrencyKey");

            modelBuilder.HasIndex(e => e.CurrencyAlternateKey)
                        .HasName("AK_DimCurrency_CurrencyAlternateKey")
                        .IsUnique();

            modelBuilder.Property(e => e.CurrencyAlternateKey)
                        .IsRequired()
                        .HasMaxLength(3);

            modelBuilder.Property(e => e.CurrencyName)
                        .IsRequired()
                        .HasMaxLength(50);
        }
    }
}