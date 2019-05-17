using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class FactFitransactionConfiguration : IEntityTypeConfiguration<FactFitransaction>
    {
        public void Configure(EntityTypeBuilder<FactFitransaction> modelBuilder)
        {
            modelBuilder.HasKey(e => e.TransactionId);

            modelBuilder.ToTable("FactFITransaction");

            modelBuilder.Property(e => e.TransactionId).HasColumnName("TransactionID");

            modelBuilder.Property(e => e.AccountBalance).HasColumnType("money");

            modelBuilder.Property(e => e.AccountNumber)
                        .HasMaxLength(30)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.InsertDateTime)
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

            modelBuilder.Property(e => e.TransactionAmount).HasColumnType("money");

            modelBuilder.Property(e => e.TransactionDescription)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Property(e => e.TransactionType)
                        .IsRequired()
                        .HasMaxLength(50);

            modelBuilder.HasOne(d => d.CompanyKeyNavigation)
                        .WithMany(p => p.FactFitransaction)
                        .HasForeignKey(d => d.CompanyKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactFITransaction_DimOrganization");

            modelBuilder.HasOne(d => d.DateKeyNavigation)
                        .WithMany(p => p.FactFitransaction)
                        .HasForeignKey(d => d.DateKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactFITransaction_DimDate");

            modelBuilder.HasOne(d => d.TimeKeyNavigation)
                        .WithMany(p => p.FactFitransaction)
                        .HasForeignKey(d => d.TimeKey)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FactFITransaction_DimTime");
        }
    }
}