using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Teacher;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Services
{
    public class TeacherService(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork, IAuthRepository userRepository, IPasswordHasher passwordHasher) : ITeacherService
         
    {
        public async Task<Result<TeacherResponse>> CreateTeacher(TeacherRequest model)
        {
            
            if(await userRepository.IsExists(x=> x.Email == model.Email))
            {
                return Result<TeacherResponse>.Failure("Email already exists", StatusCodes.Status400BadRequest);
            }

            if( await teacherRepository.IsExists(x=> x.EmployeeCode == model.EmployeeCode))
            {
                return Result<TeacherResponse>.Failure("Employee code already exists", StatusCodes.Status400BadRequest);
            }

            var transaction =  unitOfWork.BeginTrancaction();

            var user = new User(
                model.FirstName,
                model.LastName,
                model.Email,
                passwordHasher.HashPassword(model.Password),
                model.Gender,
                UserRole.Teacher
                );

            user.Deactivate();
            await userRepository.AddAsync(user);

            var teacher = new Teacher(
                user.Id,
                model.EmployeeCode,
                model.DateOfJoining
                );

            await teacherRepository.AddAsync(teacher);

            var returnVal = await unitOfWork.SaveChangesAsync();
            if( returnVal >0)
            {
                transaction.Commit();
                return Result<TeacherResponse>.Success(new TeacherResponse { Id = teacher.Id }, StatusCodes.Status201Created, "Teacher created successfully");
            }

            return Result<TeacherResponse>.Failure("Failed to create teacher", StatusCodes.Status500InternalServerError);


        }
    }
}
