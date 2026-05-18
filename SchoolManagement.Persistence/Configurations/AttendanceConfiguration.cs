using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                .IsRequired();
            builder.Property(x=>x.AttendanceStatus)
                .IsRequired();


            //relationships
            builder.HasOne(x=> x.StudentEnrollment)
                .WithMany()
                .HasForeignKey(x=>x.StudentEnrollmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
