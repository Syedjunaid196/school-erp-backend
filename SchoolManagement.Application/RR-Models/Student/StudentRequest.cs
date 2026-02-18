using SchoolManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.RR_Models.Student
{
    public class StudentRequest
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
        public Gender Gender { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;


        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string RollNumber { get; set; } = null!;
    }
}
