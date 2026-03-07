using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.Teacher;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Repository
{
    public class TeacherRepository(SchoolManagementDbContext context) : BaseRepository<Teacher>(context), ITeacherRepository
    {
        public async Task<List<TeacherListResponse>> GetTeacherList()
        {
            return await context.Teachers.Select(t => new TeacherListResponse()
            {
                Id = t.Id,
                FirstName = t.User.FirstName,
                LastName = t.User.LastName,
                Email = t.User.Email,
                Gender = t.User.Gender,
                EmployeeCode = t.EmployeeCode,
                JoiningDate = t.JoiningDate
            }).ToListAsync();                
        }
    }
}
