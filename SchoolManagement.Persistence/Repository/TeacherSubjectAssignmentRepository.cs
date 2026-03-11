using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.TeacherSubjectAssignment;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Repository
{
    public class TeacherSubjectAssignmentRepository(SchoolManagementDbContext context) : BaseRepository<TeacherSubjectAssignment>(context), ITeacherSubjectAssignmentRepository
    {
        public async Task<List<TeacherSubjectAssignmentResponse>> GetAssignments()
        {
            return await context.TeacherSubjectAssignments.Select(a => new TeacherSubjectAssignmentResponse
            {
                Id = a.Id,
                TeacherName = a.Teacher.User.FirstName + " " + a.Teacher.User.LastName,
                ClassName = a.Section.SchoolClass.Name,
                SectionName = a.Section.Name,
                SubjectName = a.Subject.Name
            }).ToListAsync();
        }
    }
}
