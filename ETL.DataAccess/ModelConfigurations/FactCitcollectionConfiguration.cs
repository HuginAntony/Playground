using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class FactCitcollectionConfiguration : IEntityTypeConfiguration<FactCitcollection>
    {
        public void Configure(EntityTypeBuilder<FactCitcollection> modelBuilder)
        {
            modelBuilder.HasKey(e => e.CollectionId)
                        .HasName("PK_CITCollection");

            modelBuilder.ToTable("FactCITCollection");

            modelBuilder.Property(e => e.CollectionId).HasColumnName("CollectionID");

            modelBuilder.Property(e => e.CanisterSerialNumber)
                        .HasMaxLength(50)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.CitcollectionTotalActualAmount)
                        .HasColumnName("CITCollectionTotalActualAmount")
                        .HasColumnType("money");

            modelBuilder.Property(e => e.CitcollectionTotalAmount)
                        .HasColumnName("CITCollectionTotalAmount")
                        .HasColumnType("money");

            modelBuilder.Property(e => e.CitcollectionTotalSurplusShortage)
                        .HasColumnName("CITCollectionTotalSurplusShortage")
                        .HasColumnType("money");

            modelBuilder.Property(e => e.CitoperatorName)
                        .HasColumnName("CITOperatorName")
                        .HasMaxLength(50)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.CollectionDateTime).HasColumnType("datetime");

            modelBuilder.Property(e => e.CorrectionReason)
                        .HasMaxLength(100)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.InsertDateTime)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

            modelBuilder.Property(e => e.SealNumber)
                        .HasMaxLength(50)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Total).HasColumnType("money");

            modelBuilder.HasOne(d => d.CollectionDateKeyNavigation)
                        .WithMany(p => p.FactCitcollection)
                        .HasForeignKey(d => d.CollectionDateKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactCITCollection_DimDate");

            modelBuilder.HasOne(d => d.CollectionTimeKeyNavigation)
                        .WithMany(p => p.FactCitcollection)
                        .HasForeignKey(d => d.CollectionTimeKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactCITCollection_DimTime");

            modelBuilder.HasOne(d => d.CompanyKeyNavigation)
                        .WithMany(p => p.FactCitcollection)
                        .HasForeignKey(d => d.CompanyKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactCITCollection_DimCompany");

            modelBuilder.HasOne(d => d.CurrencyKeyNavigation)
                        .WithMany(p => p.FactCitcollection)
                        .HasForeignKey(d => d.CurrencyKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactCITCollection_DimCurrency");

            modelBuilder.HasOne(d => d.DataVendorKeyNavigation)
                        .WithMany(p => p.FactCitcollection)
                        .HasForeignKey(d => d.DataVendorKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactCITCollection_DimDataVendor");

            modelBuilder.HasOne(d => d.LocationKeyNavigation)
                        .WithMany(p => p.FactCitcollection)
                        .HasForeignKey(d => d.LocationKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactCITCollection_DimLocation");
        }
    }
}