using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimFinancialInstitutionConfiguration : IEntityTypeConfiguration<DimFinancialInstitution>
    {
        public void Configure(EntityTypeBuilder<DimFinancialInstitution> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Fikey);

            modelBuilder.HasIndex(e => e.FialternateKey)
                        .HasName("IX_DimFinancialInstitution")
                        .IsUnique();

            modelBuilder.Property(e => e.Fikey).HasColumnName("FIKey");

            modelBuilder.Property(e => e.AccountRange)
                        .HasMaxLength(10)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.FialternateKey)
                        .IsRequired()
                        .HasColumnName("FIAlternateKey")
                        .HasMaxLength(50);

            modelBuilder.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50);
        }
    }
}