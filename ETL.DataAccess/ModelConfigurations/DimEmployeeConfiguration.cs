using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class DimEmployeeConfiguration : IEntityTypeConfiguration<DimEmployee>
    {
        public void Configure(EntityTypeBuilder<DimEmployee> modelBuilder)
        {
            modelBuilder.HasKey(e => e.EmployeeKey)
                        .HasName("PK_DimEmployee_EmployeeKey");

            modelBuilder.HasIndex(e => e.EmployeeKey)
                        .HasName("IX_DimEmployee_SSN")
                        .IsUnique();

            modelBuilder.Property(e => e.City).HasMaxLength(64);

            modelBuilder.Property(e => e.CurrentFlag)
                        .IsRequired()
                        .HasDefaultValueSql("((1))");

            modelBuilder.Property(e => e.DateOfBirth).HasColumnType("date");

            modelBuilder.Property(e => e.DepartmentName).HasMaxLength(50);

            modelBuilder.Property(e => e.Dlnumber)
                        .HasColumnName("DLNumber")
                        .HasMaxLength(30)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Dlstate)
                        .HasColumnName("DLState")
                        .HasMaxLength(19)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.EndDate).HasColumnType("date");

            modelBuilder.Property(e => e.Etlid)
                        .HasColumnName("ETLID")
                        .HasMaxLength(10);

            modelBuilder.Property(e => e.FirstName)
                        .IsRequired()
                        .HasMaxLength(30);

            modelBuilder.Property(e => e.Gender)
                        .HasMaxLength(10)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.HireDate).HasColumnType("date");

            modelBuilder.Property(e => e.HomePhone)
                        .HasMaxLength(15)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.LastName)
                        .IsRequired()
                        .HasMaxLength(30);

            modelBuilder.Property(e => e.MaritalStatus)
                        .HasMaxLength(10)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.MiddleName).HasMaxLength(30);

            modelBuilder.Property(e => e.Prefix)
                        .HasMaxLength(4)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.SocialSecurityNumber)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.StartDate).HasColumnType("date");

            modelBuilder.Property(e => e.State)
                        .HasMaxLength(19)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.StreetAddress1).HasMaxLength(45);

            modelBuilder.Property(e => e.StreetAddress2).HasMaxLength(45);

            modelBuilder.Property(e => e.Suffix)
                        .HasMaxLength(4)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.WorkPhone)
                        .HasMaxLength(15)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.Zip)
                        .HasMaxLength(5)
                        .IsUnicode(false);
        }
    }
}