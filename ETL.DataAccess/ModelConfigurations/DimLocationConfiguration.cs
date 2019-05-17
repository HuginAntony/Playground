using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimLocationConfiguration : IEntityTypeConfiguration<DimLocation>
    {
        public void Configure(EntityTypeBuilder<DimLocation> modelBuilder)
        {
            modelBuilder.HasKey(e => e.LocationKey);

            modelBuilder.HasIndex(e => e.LocationId)
                        .HasName("IX_DimLocation")
                        .IsUnique();

            modelBuilder.Property(e => e.EndDate).HasColumnType("datetime");

            modelBuilder.Property(e => e.Etlid).HasColumnName("ETLID");

            modelBuilder.Property(e => e.IsCurrent)
                        .IsRequired()
                        .HasDefaultValueSql("((1))");

            modelBuilder.Property(e => e.LocationCity)
                        .HasMaxLength(50)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.LocationCountry).HasMaxLength(80);

            modelBuilder.Property(e => e.LocationDescription).HasMaxLength(100);

            modelBuilder.Property(e => e.LocationGpslatitude)
                        .HasColumnName("LocationGPSLatitude")
                        .HasColumnType("decimal(9, 6)");

            modelBuilder.Property(e => e.LocationGpslongtitude)
                        .HasColumnName("LocationGPSLongtitude")
                        .HasColumnType("decimal(9, 6)");

            modelBuilder.Property(e => e.LocationId)
                        .IsRequired()
                        .HasColumnName("LocationID")
                        .HasMaxLength(30);

            modelBuilder.Property(e => e.LocationState)
                        .HasMaxLength(2)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.LocationZip).HasColumnName("LocationZIP");

            modelBuilder.Property(e => e.StartDate).HasColumnType("datetime");
        }
    }
}