using SchoolManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.RR_Models.Teacher
{
    public class TeacherRequest
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;

        [Required]
        [MinLength(3)]
        public string EmployeeCode { get; set; } = null!;

        [Required]
        public DateTime DateOfJoining { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
