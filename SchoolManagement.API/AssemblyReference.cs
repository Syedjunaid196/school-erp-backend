using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Application;
using SchoolManagement.Application.Validators;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Security;
using SchoolManagement.Persistence;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
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


            services.AddValidatorsFromAssemblyContaining<StudentRequestValidator>();
            services.AddFluentValidationAutoValidation(options =>
            {
                options.DisableBuiltInModelValidation = true;                                                                 
            });





            //cors policy 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000") //my frontend url for development 
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials(); // Allow cookies to be sent with requests
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
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(jwt.Key))
                 };

                 // 🔥 THIS IS THE IMPORTANT PART
                 options.Events = new JwtBearerEvents
                 {
                     OnMessageReceived = context =>
                     {
                         var token = context.Request.Cookies["accessToken"];

                         if (!string.IsNullOrEmpty(token))
                         {
                             context.Token = token;
                         }

                         return Task.CompletedTask;
                     }
                 };
             });


            return services;
        }
    }
}
