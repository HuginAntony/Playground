using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimCompanyAccountConfiguration : IEntityTypeConfiguration<DimCompanyAccount>
    {
        public void Configure(EntityTypeBuilder<DimCompanyAccount> modelBuilder)
        {
            modelBuilder.HasKey(e => e.AccountKey)
                        .HasName("PK_DimAccounts");

            modelBuilder.Property(e => e.AccountNumber)
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.CurrentFlag).HasDefaultValueSql("((1))");

            modelBuilder.Property(e => e.EndDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.Fikey).HasColumnName("FIKey");

            modelBuilder.Property(e => e.StartDate).HasColumnType("datetime");

            modelBuilder.HasOne(d => d.FikeyNavigation)
                        .WithMany(p => p.DimCompanyAccount)
                        .HasForeignKey(d => d.Fikey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DimAccounts_DimFinancialInstitution");

            modelBuilder.HasOne(d => d.OrganizationKeyNavigation)
                        .WithMany(p => p.DimCompanyAccount)
                        .HasForeignKey(d => d.OrganizationKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DimAccount_DimOrganization");
        }
    }
}