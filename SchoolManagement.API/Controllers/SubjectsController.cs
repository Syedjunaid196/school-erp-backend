using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Subject;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/subjects")]
    public class SubjectsController(ISubjectService subjectService): ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Result<SubjectResponse>> CreateSubject(SubjectRequest model)
        {
            var result = await subjectService.CreateSubject(model);
            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public Task<Result<List<SubjectResponse>>> GetAllSubjects()
        {
            var result = subjectService.GetAllSubjects();
            return result;
        }
    }
}
