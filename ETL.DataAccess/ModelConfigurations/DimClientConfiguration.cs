using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimClientConfiguration : IEntityTypeConfiguration<DimClient>
    {
        public void Configure(EntityTypeBuilder<DimClient> modelBuilder)
        {

            modelBuilder.HasKey(e => e.ClientKey)
                        .HasName("PK_DimCustomer_CustomerKey");

            modelBuilder.HasIndex(e => e.ClientAlternateKey)
                        .HasName("IX_DimCustomer_CustomerAlternateKey")
                        .IsUnique();

            modelBuilder.Property(e => e.AddressLine1).HasMaxLength(120);

            modelBuilder.Property(e => e.AddressLine2).HasMaxLength(120);

            modelBuilder.Property(e => e.ClientAlternateKey)
                        .IsRequired()
                        .HasMaxLength(15);

            modelBuilder.Property(e => e.CurrentFlag).HasDefaultValueSql("((1))");

            modelBuilder.Property(e => e.DateOfBirth).HasColumnType("date");

            modelBuilder.Property(e => e.EmailAddress).HasMaxLength(50);

            modelBuilder.Property(e => e.EndDate).HasColumnType("date");

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.FirstName).HasMaxLength(50);

            modelBuilder.Property(e => e.HomePhone)
                        .HasMaxLength(15)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.LastName).HasMaxLength(50);

            modelBuilder.Property(e => e.MiddleName).HasMaxLength(50);

            modelBuilder.Property(e => e.Prefix)
                        .HasMaxLength(4)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.StartDate).HasColumnType("date");

            modelBuilder.Property(e => e.Suffix)
                        .HasMaxLength(4)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.WorkPhone)
                        .HasMaxLength(15)
                        .IsUnicode(false);
        }
    }
}