using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Abstractions.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
