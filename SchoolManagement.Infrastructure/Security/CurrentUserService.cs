using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SchoolManagement.Infrastructure.Security
{
    public class CurrentUserService(IHttpContextAccessor httpContext) : ICurrentUserService
    {
        public Guid GetUserId()
        {
            var userId = httpContext.HttpContext?.User?.Claims?.FirstOrDefault(
                x => x.Type == ClaimTypes.NameIdentifier || x.Type == JwtRegisteredClaimNames.Sub)?.Value;
            if (Guid.TryParse(userId, out Guid id)) return id;
            return Guid.Empty;
        }
        public string GetEmail()
        {
            var email = httpContext.HttpContext?.User?.Claims?.FirstOrDefault(
                x=> x.Type == ClaimTypes.Email || x.Type == JwtRegisteredClaimNames.Email
                )?.Value;
            return email ?? string.Empty;


        }

        public string GetRole()
        {
            var role = httpContext.HttpContext?.User?.Claims?.FirstOrDefault(
                x => x.Type == ClaimTypes.Role || x.Type == "role")?.Value;
            return role ?? string.Empty;
        }

    }
}
