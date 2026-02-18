using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Repository
{
    public class TeacherRepository(SchoolManagementDbContext context) : BaseRepository<Teacher>(context), ITeacherRepository
    {
    }
}
