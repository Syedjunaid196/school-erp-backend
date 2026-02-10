using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.User;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public class UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : IUserService
    {
        public async Task<Result<UserResponse>> AddUser(UserRequest model)
        {
            var transaction = unitOfWork.BeginTrancaction();

            var user = new User(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password,
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
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Gender = model.Gender,
                    Role = model.Role

                }, "User Added Successfully");
            }

            return Result<UserResponse>.Failure("something went wrong", StatusCodes.Status400BadRequest);

        }
    }
}
