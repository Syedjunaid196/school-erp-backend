using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.RR_Models.AcademicYear;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Persistence.Repository
{
    public class AcademicYearRepository(SchoolManagementDbContext context) : BaseRepository<AcademicYear>(context), IAcademicYearRepository
    {
        public async Task<List<AcademicYearResponse>> GetAcademicYears()
        {
            return await context.AcademicYears.Select(ay => new AcademicYearResponse
            {
                Id = ay.Id,
                Name = ay.Name,
                StartDate = ay.StartDate,
                EndDate = ay.EndDate
            }).ToListAsync();
        }
    }
}
