using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Repository
{
    public class AcademicYearRepository(SchoolManagementDbContext context) : BaseRepository<AcademicYear>(context), IAcademicYearRepository
    {
    }
}
