using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;

namespace SchoolManagement.Persistence.Repository
{
    public class StudentRepository(SchoolManagementDbContext context) : BaseRepository<Student>(context), IStudentRepository
    {
        public async Task<List<StudentListResponse>> GetStudentListAsync()
        {
            return await context.Students.Select(s => new StudentListResponse
            {
                Id = s.Id,
                FirstName = s.User.FirstName,
                LastName = s.User.LastName,
                Gender = s.User.Gender,
                Email = s.User.Email,
                RollNumber = s.RollNumber,
                DateOfBirth = s.DateOfBirth,
                ParentName = s.Parent != null
                        ? s.Parent.User.FirstName + " " + s.Parent.User.LastName
                        : null
            })
                .ToListAsync();
        }
    }
}
