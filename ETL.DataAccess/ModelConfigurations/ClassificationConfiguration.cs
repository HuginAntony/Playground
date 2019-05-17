using ETL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETL.DataAccess.ModelConfigurations
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> modelBuilder)
        {
            modelBuilder.ToTable("Classification", "ReferenceData");

            modelBuilder.HasIndex(e => new { e.ClassificationGroupId, e.DataCode })
                        .HasName("UQ_ReferenceData_Classification")
                        .IsUnique();

            modelBuilder.Property(e => e.ClassificationId).HasColumnName("ClassificationID");

            modelBuilder.Property(e => e.ClassificationGroupId).HasColumnName("ClassificationGroupID");

            modelBuilder.Property(e => e.ClassificationHeaderId).HasColumnName("ClassificationHeaderID");

            modelBuilder.Property(e => e.ClassificationSchema)
                        .HasMaxLength(50)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.DataCode)
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

            modelBuilder.Property(e => e.DataDescription)
                        .HasMaxLength(1024)
                        .IsUnicode(false);

            modelBuilder.HasOne(d => d.ClassificationGroup)
                        .WithMany(p => p.InverseClassificationGroup)
                        .HasForeignKey(d => d.ClassificationGroupId)
                        .HasConstraintName("FK_Classification_GroupID");

            modelBuilder.HasOne(d => d.ClassificationHeader)
                        .WithMany(p => p.InverseClassificationHeader)
                        .HasForeignKey(d => d.ClassificationHeaderId)
                        .HasConstraintName("FK_Classification_HeaderID");
        }
    }
}