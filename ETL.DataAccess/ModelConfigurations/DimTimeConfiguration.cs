using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimTimeConfiguration : IEntityTypeConfiguration<DimTime>
    {
        public void Configure(EntityTypeBuilder<DimTime> modelBuilder)
        {
            modelBuilder.HasKey(e => e.TimeKey)
                        .HasName("PK_dim_Time");

            modelBuilder.HasIndex(e => e.AmPm)
                        .HasName("IDX_dim_Time_AmPm");

            modelBuilder.HasIndex(e => e.Hour)
                        .HasName("IDX_dim_Time_Hour");

            modelBuilder.HasIndex(e => e.MilitaryHour)
                        .HasName("IDX_dim_Time_MilitaryHour");

            modelBuilder.HasIndex(e => e.Minute)
                        .HasName("IDX_dim_Time_Minute");

            modelBuilder.HasIndex(e => e.Second)
                        .HasName("IDX_dim_Time_Second");

            modelBuilder.HasIndex(e => e.StandardTime)
                        .HasName("IDX_dim_Time_StandardTime");

            modelBuilder.HasIndex(e => e.Time)
                        .HasName("IDX_dim_Time_Time")
                        .IsUnique();

            modelBuilder.Property(e => e.AmPm)
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Hour)
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.MilitaryHour)
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Minute)
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Second)
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.StandardTime)
                        .HasMaxLength(11)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Time)
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false);
        }
    }
}