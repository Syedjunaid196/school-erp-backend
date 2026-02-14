using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.RR_Models.User.UserLogin
{
    public class LoginResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public UserStatus Status { get; set; }

        public string Token { get; set; } = null!;
    }
}
