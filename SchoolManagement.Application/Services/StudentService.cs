using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
    public class StudentService(IAuthRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IStudentRepository studentRepository,
        
        ILogger<StudentService> logger) : IStudentService
    {

        public async Task<Result<StudentResponse>> CreateStudent(StudentRequest model)
        {
            logger.LogInformation("Creating new student with email: {Email}", model.Email);
            if (await userRepository.IsExists(x => x.Email == model.Email))
            {
                logger.LogWarning("Student with email: {Email} already exists", model.Email);
                return Result<StudentResponse>.Failure("Email Already Exists", StatusCodes.Status400BadRequest);
            }

            if (await studentRepository.IsExists(x => x.RollNumber == model.RollNumber))
            {
                logger.LogInformation("Student with roll number: {RollNumber} already exists", model.RollNumber);
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


            var student = new Student(
                user.Id,
                model.RollNumber,
                model.DateOfBirth,
                model.ParenetId
                );

            await userRepository.AddAsync(user);
            await studentRepository.AddAsync(student);

            var returnValue = await unitOfWork.SaveChangesAsync();

            if (returnValue > 1)
            {
                transaction.Commit();
                logger.LogInformation("Student with email: {Email} created successfully", model.Email);
                return Result<StudentResponse>.Success(new StudentResponse
                {
                    Id = student.Id
                }, StatusCodes.Status201Created, "Student created successfully");
            }
            logger.LogError("Failed to create student with email: {Email}", model.Email);   
            return Result<StudentResponse>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
            
        }

        public async Task<Result<StudentResponse>> DeleteStudentByIdAsync(Guid id)
        {
            var student = studentRepository.GetByIdAsync(id);
            if (student is not null)
            {
                await studentRepository.DeletebyIdAsync(id);
                var returnValue = await unitOfWork.SaveChangesAsync();
                if (returnValue > 0)
                {
                    return Result<StudentResponse>.Success(new StudentResponse
                    {
                        Id = id
                    }, StatusCodes.Status200OK, "Student deleted successfully");
                }
            }
            return Result<StudentResponse>.Failure("Student not found", StatusCodes.Status404NotFound);
        }

        public async Task<Result<List<StudentListResponse>>> GetAllStudents()
        {
            var students = await studentRepository.GetStudentListAsync();
            return Result<List<StudentListResponse>>.Success(students);
        }
    }
}

