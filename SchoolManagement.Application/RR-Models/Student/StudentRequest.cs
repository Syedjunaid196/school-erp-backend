using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.RR_Models.Student
{
    public class StudentRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Gender Gender { get; set; }
        public string Password { get; set; } = null!;
        public string RollNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public Guid? ParenetId { get; set; }
    }
}
