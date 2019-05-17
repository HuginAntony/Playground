using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimDateConfiguration : IEntityTypeConfiguration<DimDate>
    {
        public void Configure(EntityTypeBuilder<DimDate> modelBuilder)
        {
            modelBuilder.HasKey(e => e.DateKey)
                        .HasName("PK_DimDate_DateKey");

            modelBuilder.Property(e => e.DateKey).ValueGeneratedNever();

            modelBuilder.Property(e => e.Date).HasColumnType("date");

            modelBuilder.Property(e => e.DaySuffix)
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.DowinMonth).HasColumnName("DOWInMonth");

            modelBuilder.Property(e => e.FirstDayOfMonth).HasColumnType("date");

            modelBuilder.Property(e => e.FirstDayOfNextMonth).HasColumnType("date");

            modelBuilder.Property(e => e.FirstDayOfNextYear).HasColumnType("date");

            modelBuilder.Property(e => e.FirstDayOfQuarter).HasColumnType("date");

            modelBuilder.Property(e => e.FirstDayOfYear).HasColumnType("date");

            modelBuilder.Property(e => e.HolidayText)
                        .HasMaxLength(64)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.IsoweekOfYear).HasColumnName("ISOWeekOfYear");

            modelBuilder.Property(e => e.LastDayOfMonth).HasColumnType("date");

            modelBuilder.Property(e => e.LastDayOfQuarter).HasColumnType("date");

            modelBuilder.Property(e => e.LastDayOfYear).HasColumnType("date");

            modelBuilder.Property(e => e.Mmyyyy)
                        .IsRequired()
                        .HasColumnName("MMYYYY")
                        .HasMaxLength(6)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.MonthName)
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.MonthYear)
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.QuarterName)
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.WeekDayName)
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false);
        }
    }
}