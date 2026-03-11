using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.SchoolClass;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/classes")]
    public class SchoolClassController(ISchoolClassService schoolClassService) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Result<SchoolClassResponse>> CreateSchoolClass(SchoolClassRequest model)
        {
            var result = await schoolClassService.CreateSchoolClass(model);
            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<Result<List<SchoolClassResponse>>> GetSchoolClasses()
        {
            var result = await schoolClassService.GetSchoolClasses();
            return result;
        }
    }
}
