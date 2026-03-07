using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.RR_Models.Teacher
{
    public class TeacherRequest
    {
        
        public string FirstName { get; set; } = null!;

        
        public string LastName { get; set; } = null!;

        public Gender Gender { get; set; }
        
        public string Email { get; set; } = null!;
        
        public string Password { get; set; } = null!;

        public string EmployeeCode { get; set; } = null!;

        public DateTime DateOfJoining { get; set; }

     
    }
}
