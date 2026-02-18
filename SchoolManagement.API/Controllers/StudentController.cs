using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController(IStudentService studentService): ControllerBase
    {
        [HttpPost]
        public async Task<Result<StudentResponse>> CreateStudent(StudentRequest model)
        {
            var result = await studentService.CreateStudent(model);
            return result;
        }
    }
}
