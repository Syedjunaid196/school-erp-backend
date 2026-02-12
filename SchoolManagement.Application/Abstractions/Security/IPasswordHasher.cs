using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Abstractions.Security
{
    public interface IPasswordHasher
    {
        string GenetateSalt();
        string HashPassword(string password);

        bool VerifyPassword(string password, string hashedPassword);
    }
}
