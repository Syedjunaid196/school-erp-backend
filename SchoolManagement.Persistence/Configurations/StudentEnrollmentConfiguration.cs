using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class StudentEnrollmentConfiguration : BaseEntityConfiguration<StudentEnrollment>
    {
        public override void Configure(EntityTypeBuilder<StudentEnrollment> builder)
        {
            base.Configure(builder);

            builder.ToTable("StudentEnrollments");

            builder.HasOne(se => se.Student)
                   .WithMany()
                   .HasForeignKey(se => se.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(se => se.Section)
                   .WithMany()
                   .HasForeignKey(se => se.SectionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(se => se.AcademicYear)
                   .WithMany()
                   .HasForeignKey(se => se.AcademicYearId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(se => new { se.StudentId, se.AcademicYearId })
                   .IsUnique();
        }
    }
}
