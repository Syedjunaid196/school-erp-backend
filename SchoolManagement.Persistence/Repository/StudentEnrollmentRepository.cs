using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.StudentEnrollment;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Repository
{
    public class StudentEnrollmentRepository(SchoolManagementDbContext context) : BaseRepository<StudentEnrollment>(context), IStudentEnrollmentRepository
    {
        public async Task<List<StudentEnrollmentResponse>> GetEnrollments()
        {
            return await context.StudentEnrollments.AsNoTracking().Select(se => new StudentEnrollmentResponse
            {
                Id = se.Id,
                StudentName = se.Student.User.FirstName + " " + se.Student.User.LastName,
                AcademicYearName = se.AcademicYear.Name,
                ClassName = se.Section.SchoolClass.Name,
                SectionName = se.Section.Name
            }).ToListAsync();
        }
    }
}
