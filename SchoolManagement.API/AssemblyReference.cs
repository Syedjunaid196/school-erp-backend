using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Application;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Security;
using SchoolManagement.Persistence;
using System.Text;

namespace SchoolManagement.API
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices()
                    .AddPersistenceServices(configuration)
                    .AddInfrastructureServices();

            //cors policy 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000") //my frontend url for development 
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            //jwt authentication

            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwt = configuration.GetSection("Jwt").Get<JwtOptions>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwt!.Issuer,
                        ValidAudience = jwt!.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key))
                    };
                });



            return services;
        }
    }
}
