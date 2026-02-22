using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Persistence.Configurations
{
    public class StudentConfiguration : BaseEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Students");//table name in database

            //builder.HasKey(s => s.Id); // defines primary key
            //add constraints like foreign key, required fields, max length etc.
            builder.Property(s => s.RollNumber)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(s => s.RollNumber)
                .IsUnique(); // Ensure RollNumber is unique
            builder.Property(s => s.DateOfBirth)
                .IsRequired();
            builder.HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //  Parent relationship
            builder.HasOne(s => s.Parent)
                   .WithMany(p => p.Students)
                   .HasForeignKey(s => s.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
