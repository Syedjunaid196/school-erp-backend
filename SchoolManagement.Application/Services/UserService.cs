using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.User;
using SchoolManagement.Application.RR_Models.User.UserLogin;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public class UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IPasswordHasher bcryptPasswordHasher,
        IJwtTokenGenerator jwtTokenGenerator) : IUserService
    {
        public async Task<Result<UserResponse>> AddUser(UserRequest model)
        {
            var isEmailExist = await userRepository.IsExists(x => x.Email == model.Email);
            if (isEmailExist)
            {
                return Result<UserResponse>.Failure("Email already exists", StatusCodes.Status400BadRequest);
            }
            //var salt = bcryptPasswordPassword.GenetateSalt();
            var hashPassword = bcryptPasswordHasher.HashPassword(model.Password);
            var transaction = unitOfWork.BeginTrancaction();

            var user = new User(
                model.FirstName,
                model.LastName,
                model.Email,
                hashPassword,
                model.Gender,
                model.Role
                );

            await userRepository.AddAsync(user);

            var returnValue = await unitOfWork.SaveChangesAsync();
            if (returnValue > 0)
            {
                transaction.Commit();
                return Result<UserResponse>.Success(new UserResponse
                {
                    Id = user.Id,                    
                }, StatusCodes.Status201Created, "User Added Successfully");
            }

            return Result<UserResponse>.Failure("something went wrong", StatusCodes.Status500InternalServerError);

        }

        public async Task<Result<LoginResponse>> UserLogin(LoginRequest model)
        {
            var user = await userRepository.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user is null)
            {
                return Result<LoginResponse>.Failure("Invalid Email Or Password", StatusCodes.Status400BadRequest);
            }

            var isPasswordValid = bcryptPasswordHasher.VerifyPassword(model.Password, user.HasPassword);
            if (!isPasswordValid)
            {
                return Result<LoginResponse>.Failure("Invalid Email Or Password", StatusCodes.Status400BadRequest);
            }

            if (user.Status != Domain.Enums.UserStatus.Active)
            {
                return Result<LoginResponse>.Failure("User account is not approved yet", StatusCodes.Status403Forbidden);
            }

            var token = jwtTokenGenerator.GenerateToken(user);

            var response = new LoginResponse
            {
                Id = user.Id,
                Email = user.Email,
                Status = user.Status,
                Role = user.Role,
                Token = token
            };

            return Result<LoginResponse>.Success(response, "Login Successful");
        }
    }
}
