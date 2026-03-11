using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.AcademicYear;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/academic-years")]
    public class AcademicYearController(IAcademicYearService academicYearService) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Result<AcademicYearResponse>> CreateAcademicYear(AcademicYearRequest model)
        {
            var result = await academicYearService.CreateAcademicYear(model);
            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<Result<List<AcademicYearResponse>>> GetAcademicYears()
        {
            var result = await academicYearService.GetAcademicYears();
            return result;
        }
    }
}
