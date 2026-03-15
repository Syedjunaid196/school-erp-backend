using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.StudentEnrollment;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/student-enrollments")]
    public class StudentEnrollmentController(IStudentEnrollmentService studentEnrollmentService) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Result<StudentEnrollmentResponse>> EnrollStudent(StudentEnrollmentRequest model)
        {
            var result = await studentEnrollmentService.EnrollStudent(model);
            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<Result<List<StudentEnrollmentResponse>>> GetEnrollments()
        {
            var result = await studentEnrollmentService.GetEnrollments();
            return result;
        }
    }
}
