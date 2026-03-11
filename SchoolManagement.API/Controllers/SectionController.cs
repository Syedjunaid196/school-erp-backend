using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Section;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionController(ISectionService sectionService): ControllerBase
    {
        [HttpPost]
        public async Task<Result<SectionResponse>> CreateSection(SectionRequest model)
        {
            var result  = await sectionService.CreateSection(model);
            return result;
        }

        [HttpGet]
        public async Task<Result<List<SectionResponse>>> GetSections()
        {
            var result  = await sectionService.GetSections();
            return result;
        }
    }
}
