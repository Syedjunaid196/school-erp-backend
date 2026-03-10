using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Parent;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Services
{
    public class ParentService(IParentRepository parentRepository,
        IAuthRepository authRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher) : IParentService
    {
        public async Task<Result<ParentResponse>> AddParent(ParentRequest model)
        {
            if (await authRepository.IsExists(x => x.Email == model.Email))
            {
                return Result<ParentResponse>.Failure("Email already exists", StatusCodes.Status400BadRequest);
            }

            var hashedPassword = passwordHasher.HashPassword(model.Password);
            var transaction = unitOfWork.BeginTrancaction();

            var user = new User(
               firstName: model.FirstName,
               lastName: model.LastName,
               email: model.Email,
               hashpassword: hashedPassword,
               gender: model.Gender,
               role: UserRole.Parent
                );

            var parent = new Parent(
                user.Id,
                model.Occupation,
                model.Address
                );

            await authRepository.AddAsync(user);
            await parentRepository.AddAsync(parent);

            var result = await unitOfWork.SaveChangesAsync();
            if (result > 0)
            {
                transaction.Commit();
                return Result<ParentResponse>.Success(new ParentResponse { Id = parent.Id }, StatusCodes.Status201Created, "Parent Created Successfully");
            }
            transaction.Rollback();
            return Result<ParentResponse>.Failure("Failed to create parent", StatusCodes.Status500InternalServerError);

        }

        public async Task<Result<List<ParentListResponse>>> GetParentList()
        {
            var parents = await parentRepository.GetParentList();
            if (parents.Count >= 0)
            {
                return Result<List<ParentListResponse>>.Success(parents, StatusCodes.Status200OK, "Parents Fetched successfully");
            }
            return Result<List<ParentListResponse>>.Failure("No parents found", StatusCodes.Status404NotFound);
        }
    }
}
