using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Section;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/sections")]
    public class SectionController(ISectionService sectionService): ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Result<SectionResponse>> CreateSection(SectionRequest model)
        {
            var result  = await sectionService.CreateSection(model);
            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<Result<List<SectionResponse>>> GetSections()
        {
            var result  = await sectionService.GetSections();
            return result;
        }
    }
}
