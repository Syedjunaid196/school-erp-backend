using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Application.Services;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{ 
    [ApiController]
    [Route("api/students")]
    [Authorize]
    public class StudentController(IStudentService studentService): ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Result<StudentResponse>> CreateStudent(StudentRequest model)
        {
            var result = await studentService.CreateStudent(model);
            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<Result<List<StudentListResponse>>> GetAllStudents()
        {
            var result = await studentService.GetAllStudents();

            return result;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<Result<StudentResponse>> DeleteStudentByIdAsync(Guid id)
        {
            var result = await studentService.DeleteStudentByIdAsync(id);
            return result;
        }
    }
}
