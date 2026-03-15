using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Teacher;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/teachers")]
    public class TeacherController(ITeacherService teacherService) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Result<TeacherResponse>> CreateTeacher(TeacherRequest model)
        {
            var result = await teacherService.CreateTeacher(model);
            return result;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<Result<List<TeacherListResponse>>> GetTeacher()
        {
            var result = await teacherService.GetTeachersList();
            return result;
        }
    }
}
