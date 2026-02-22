using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class AcademicYearConfiguration : BaseEntityConfiguration<AcademicYear>
    {
        public override void Configure(EntityTypeBuilder<AcademicYear> builder)
        {
            base.Configure(builder);

            builder.ToTable("AcademicYears");

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.StartDate)
                   .IsRequired();

            builder.Property(a => a.EndDate)
                   .IsRequired();

            builder.HasIndex(a => a.Name)
                   .IsUnique();
        }
    }
}
