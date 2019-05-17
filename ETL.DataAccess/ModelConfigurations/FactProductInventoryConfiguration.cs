using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class FactProductInventoryConfiguration : IEntityTypeConfiguration<FactProductInventory>
    {
        public void Configure(EntityTypeBuilder<FactProductInventory> modelBuilder)
        {
            modelBuilder.HasKey(e => e.InventoryKey);

            modelBuilder.HasIndex(e => new { e.ProductKey, e.CompanyKey, e.HoldQty, e.BreakageQty, e.IntransitQty, e.AllocatedQty, e.AddQty, e.SalesQty, e.DateKey })
                        .HasName("IX_Inventory1");

            modelBuilder.Property(e => e.AddQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.AllocatedQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.BatchNumber).HasMaxLength(30);

            modelBuilder.Property(e => e.BeginningQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.BreakageQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.ExpiryDate).HasColumnType("date");

            modelBuilder.Property(e => e.HoldQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.InsertDateTime)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

            modelBuilder.Property(e => e.IntransitQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.IsExpired).HasComputedColumnSql("(case when datediff(day,isnull([ExpiryDate],getdate()),getdate())>(0) then (1) else (0) end)");

            modelBuilder.Property(e => e.LotNumber).HasMaxLength(30);

            modelBuilder.Property(e => e.ManufacturingDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.MovementDate).HasColumnType("date");

            modelBuilder.Property(e => e.OpenQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.SalesQty).HasDefaultValueSql("((0))");

            modelBuilder.Property(e => e.UnitCost).HasColumnType("money");

            modelBuilder.Property(e => e.UnitPrice).HasColumnType("money");

            modelBuilder.HasOne(d => d.CompanyKeyNavigation)
                        .WithMany(p => p.FactProductInventory)
                        .HasForeignKey(d => d.CompanyKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactProductInventory_DimOrganization");

            modelBuilder.HasOne(d => d.DateKeyNavigation)
                        .WithMany(p => p.FactProductInventory)
                        .HasForeignKey(d => d.DateKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactProductInventory_DimDate");

            modelBuilder.HasOne(d => d.LocationKeyNavigation)
                        .WithMany(p => p.FactProductInventory)
                        .HasForeignKey(d => d.LocationKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactProductInventory_DimLocation");

            modelBuilder.HasOne(d => d.ProductKeyNavigation)
                        .WithMany(p => p.FactProductInventory)
                        .HasForeignKey(d => d.ProductKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactProductInventory_DimProduct");

            modelBuilder.HasOne(d => d.TimeKeyNavigation)
                        .WithMany(p => p.FactProductInventory)
                        .HasForeignKey(d => d.TimeKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactProductInventory_DimTime");

            modelBuilder.HasOne(d => d.VendorKeyNavigation)
                        .WithMany(p => p.FactProductInventory)
                        .HasForeignKey(d => d.VendorKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactProductInventory_DimDataVendor");
        }
    }
}