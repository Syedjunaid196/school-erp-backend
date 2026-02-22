using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class TeacherSubjectAssignmentConfiguration : BaseEntityConfiguration<TeacherSubjectAssignment>
    {
        public override void Configure(EntityTypeBuilder<TeacherSubjectAssignment> builder)
        {
            base.Configure(builder);

            builder.ToTable("TeacherSubjectAssignments");

            builder.HasOne(t => t.Teacher)
                   .WithMany()
                   .HasForeignKey(t => t.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Subject)
                   .WithMany()
                   .HasForeignKey(t => t.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Section)
                   .WithMany()
                   .HasForeignKey(t => t.SectionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => new { t.TeacherId, t.SubjectId, t.SectionId })
                   .IsUnique();
        }
    }
}
