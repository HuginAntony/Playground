using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimCompanyConfiguration : IEntityTypeConfiguration<DimCompany>
    {
        public void Configure(EntityTypeBuilder<DimCompany> modelBuilder)
        {
            modelBuilder.HasKey(e => e.CompanyKey)
                    .HasName("PK_DimOrganization");

                modelBuilder.Property(e => e.AddressVerified).HasDefaultValueSql("((0))");

                modelBuilder.Property(e => e.AlternateKey)
                    .IsRequired()
                    .HasMaxLength(15);

                modelBuilder.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.CitcollectionCycle)
                    .HasColumnName("CITCollectionCycle")
                    .HasDefaultValueSql("((7))");

                modelBuilder.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.CityGl)
                    .HasColumnName("CityGL")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.CityTaxRate).HasColumnType("decimal(3, 2)");

                modelBuilder.Property(e => e.CompanyDba)
                    .HasColumnName("CompanyDBA")
                    .HasMaxLength(60);

                modelBuilder.Property(e => e.Country).HasMaxLength(100);

                modelBuilder.Property(e => e.DateApproved).HasColumnType("date");

                modelBuilder.Property(e => e.DepositRequirement).HasColumnType("decimal(3, 2)");

                modelBuilder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.EndDate).HasColumnType("datetime");

                modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

                modelBuilder.Property(e => e.Fein).HasColumnName("FEIN");

                modelBuilder.Property(e => e.Feinverified).HasColumnName("FEINVerified");

                modelBuilder.Property(e => e.Fikey).HasColumnName("FIKey");

                modelBuilder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                modelBuilder.Property(e => e.NameVerified).HasDefaultValueSql("((0))");

                modelBuilder.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.PhoneVerified).HasDefaultValueSql("((0))");

                modelBuilder.Property(e => e.ProjectedAnnualSales)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                modelBuilder.Property(e => e.ProjectedDailySales)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(([ProjectedAnnualSales]*(1))/(365))");

                modelBuilder.Property(e => e.ProjectedWeeklySales)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(([ProjectedAnnualSales]*(7))/(365))");

                modelBuilder.Property(e => e.SettlementAccount)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.StartDate).HasColumnType("datetime");

                modelBuilder.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.StateGl)
                    .HasColumnName("StateGL")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                modelBuilder.Property(e => e.StateTaxRate).HasColumnType("decimal(3, 2)");

                modelBuilder.Property(e => e.StreetAddress1).IsRequired();

                modelBuilder.HasOne(d => d.FikeyNavigation)
                    .WithMany(p => p.DimCompany)
                    .HasForeignKey(d => d.Fikey)
                    .HasConstraintName("FK_DimOrganization_DimFinancialInstitution");

                modelBuilder.HasOne(d => d.ParentCompanyKeyNavigation)
                    .WithMany(p => p.InverseParentCompanyKeyNavigation)
                    .HasForeignKey(d => d.ParentCompanyKey)
                    .HasConstraintName("FK_DimOrganization_DimOrganization");
            
        }
    }
}
