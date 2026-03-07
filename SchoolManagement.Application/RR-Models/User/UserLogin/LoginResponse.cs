using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.RR_Models.User.UserLogin
{
    public class LoginResponse
    {
        public Guid Id { get; set; }

        public UserRole Role { get; set; }

        public string Token { get; set; } = null!;
    }
}
