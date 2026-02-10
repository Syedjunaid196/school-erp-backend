using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.RR_Models.User
{
    public class UserRequest
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;

        public Gender Gender { get; init; }

        public UserRole Role { get; init; }

    }
}
