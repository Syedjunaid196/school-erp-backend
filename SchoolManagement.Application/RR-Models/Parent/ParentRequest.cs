using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.RR_Models.Parent
{
    public class ParentRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Gender Gender { get; set; }

        public string Occupation { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
