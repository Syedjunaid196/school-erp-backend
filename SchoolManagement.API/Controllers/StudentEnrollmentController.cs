using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.StudentEnrollment;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class StudentEnrollmentController(IStudentEnrollmentService studentEnrollmentService) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<StudentEnrollmentResponse>> EnrollStudent(StudentEnrollmentRequest model)
        {
            var result = await studentEnrollmentService.EnrollStudent(model);
            return result;
        }

        [HttpGet]
        public async Task<Result<List<StudentEnrollmentResponse>>> GetEnrollments()
        {
            var result = await studentEnrollmentService.GetEnrollments();
            return result;
        }
    }
}
