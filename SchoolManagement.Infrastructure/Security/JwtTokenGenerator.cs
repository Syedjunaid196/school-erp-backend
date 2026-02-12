using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Infrastructure.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
