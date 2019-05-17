using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class FactSalesConfiguration : IEntityTypeConfiguration<FactSales>
    {
        public void Configure(EntityTypeBuilder<FactSales> modelBuilder)
        {
            modelBuilder.HasKey(e => e.SalesId)
                        .HasName("PK_FactSales_1");

            modelBuilder.Property(e => e.SalesId).HasColumnName("SalesID");

            modelBuilder.Property(e => e.CitdepositId).HasColumnName("CITDepositID");

            modelBuilder.Property(e => e.CityTax).HasColumnType("money");

            modelBuilder.Property(e => e.CityTaxDepositId).HasColumnName("CityTaxDepositID");

            modelBuilder.Property(e => e.CountyTax).HasColumnType("money");

            modelBuilder.Property(e => e.DueDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.ExpectedCityTax).HasColumnType("money");

            modelBuilder.Property(e => e.ExpectedDeposit).HasColumnType("money");

            modelBuilder.Property(e => e.ExpectedStateTax).HasColumnType("money");

            modelBuilder.Property(e => e.FidepositId).HasColumnName("FIDepositID");

            modelBuilder.Property(e => e.Freight).HasColumnType("money");

            modelBuilder.Property(e => e.InsertDateTime)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

            modelBuilder.Property(e => e.NetAmount).HasColumnType("money");

            modelBuilder.Property(e => e.OrderDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.Posid)
                        .IsRequired()
                        .HasColumnName("POSID")
                        .HasMaxLength(30);

            modelBuilder.Property(e => e.PosuserId)
                        .HasColumnName("POSUserID")
                        .HasMaxLength(50);

            modelBuilder.Property(e => e.SaleOrderNumber)
                        .IsRequired()
                        .HasMaxLength(20);

            modelBuilder.Property(e => e.SalePrice).HasColumnType("money");

            modelBuilder.Property(e => e.SalesAmount).HasColumnType("money");

            modelBuilder.Property(e => e.ShipDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.StateTax).HasColumnType("money");

            modelBuilder.Property(e => e.StateTaxDepositId).HasColumnName("StateTaxDepositID");

            modelBuilder.Property(e => e.UnitCost).HasColumnType("money");

            modelBuilder.Property(e => e.UnitPrice).HasColumnType("money");

            modelBuilder.HasOne(d => d.CompanyKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.CompanyKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactSales_DimOrganization");

            modelBuilder.HasOne(d => d.CurrencyKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.CurrencyKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactSales_DimCurrency");

            modelBuilder.HasOne(d => d.LocationKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.LocationKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactSales_DimLocation");

            modelBuilder.HasOne(d => d.OrderDateKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.OrderDateKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactSales_DimDate");

            modelBuilder.HasOne(d => d.OrderTimeKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.OrderTimeKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactSales_DimTime");

            modelBuilder.HasOne(d => d.ProductKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.ProductKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactSales_DimProduct");

            modelBuilder.HasOne(d => d.PromotionKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.PromotionKey)
                        .HasConstraintName("FK_FactSales_DimPromotion");

            modelBuilder.HasOne(d => d.SalesEmployeeKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.SalesEmployeeKey)
                        .HasConstraintName("FK_FactSales_DimEmployee");

            modelBuilder.HasOne(d => d.VendorKeyNavigation)
                        .WithMany(p => p.FactSales)
                        .HasForeignKey(d => d.VendorKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactSales_DimDataVendor");
        }
    }
}