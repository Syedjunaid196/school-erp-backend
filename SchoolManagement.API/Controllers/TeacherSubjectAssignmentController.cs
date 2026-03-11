using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.TeacherSubjectAssignment;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/teacher-subject-assignments")]
    public class TeacherSubjectAssignmentController(ITeacherSubjectAssignmentService teacherSubjectAssignmentService): ControllerBase
    {
        [HttpPost]
        public async Task<Result<TeacherSubjectAssignmentResponse>> AssignTeacher(TeacherSubjectAssignmentRequest model)
        {
            var result = await teacherSubjectAssignmentService.AssignTeacher(model);
            return result;
            
        }

        [HttpGet]
        public Task<Result<List<TeacherSubjectAssignmentResponse>>> GetAllAssignments()
        {
            var result = teacherSubjectAssignmentService.GetAllAssignments();
            return result;
        }
    }
}
