using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Services
{
    public class StudentService(IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IStudentRepository studentRepository) : IStudentService
    {
        public async Task<Result<StudentResponse>> CreateStudent(StudentRequest model)
        {
            if (await userRepository.IsExists(x => x.Email == model.Email))
            {
                return Result<StudentResponse>.Failure("Email Already Exists", StatusCodes.Status400BadRequest);
            }

            if(await studentRepository.IsExists(x => x.RollNumber == model.RollNumber))
            {
                return Result<StudentResponse>.Failure("Roll Number Already Exists", StatusCodes.Status400BadRequest);
            }

            var transaction = unitOfWork.BeginTrancaction();


            var user = new User(
                model.FirstName,
                model.LastName,
                model.Email,
                passwordHasher.HashPassword(model.Password),
                model.Gender,
                UserRole.Student
                );

            user.Deactivate();


            var student = new Student(
                user.Id,
                model.RollNumber,
                model.DateOfBirth
                );

            await userRepository.AddAsync(user);
            await studentRepository.AddAsync(student);

            var returnValue = await unitOfWork.SaveChangesAsync();

            if (returnValue > 1)
            {
                transaction.Commit();
                return Result<StudentResponse>.Success(new StudentResponse
                {
                    Id = student.Id
                }, StatusCodes.Status201Created, "Student created successfully");
            }
            return Result<StudentResponse>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);


        }
    }
}

