using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class TeacherConfiguration : BaseEntityConfiguration<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            builder.ToTable("Teachers");

            builder.Property(t => t.EmployeeCode)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(t => t.EmployeeCode)
                .IsUnique();

            builder.Property(t => t.JoiningDate)
                .IsRequired();

            builder.HasOne(t => t.User)
                .WithOne()
                .HasForeignKey<Teacher>(t=> t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
