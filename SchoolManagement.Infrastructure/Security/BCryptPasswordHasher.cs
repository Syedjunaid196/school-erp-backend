using SchoolManagement.Application.Abstractions.Security;

namespace SchoolManagement.Infrastructure.Security
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string GenetateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
