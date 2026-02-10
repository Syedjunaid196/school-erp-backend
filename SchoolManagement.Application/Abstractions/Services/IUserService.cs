using SchoolManagement.Application.RR_Models.User;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<Result<UserResponse>> AddUser(UserRequest model);


    }
}
