using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.StudentEnrollment;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Services
{
    public class StudentEnrollmentService(IStudentEnrollmentRepository studentEnrollmentRepository,
        IStudentRepository studentRepository,
        IAcademicYearRepository academicYearRepository,
        ISectionRepository sectionRepository,
        IUnitOfWork unitOfWork) : IStudentEnrollmentService
    {
        public async Task<Result<StudentEnrollmentResponse>> EnrollStudent(StudentEnrollmentRequest model)
        {
            if(!await studentRepository.IsExists(x=> x.Id == model.StudentId))
            {
                return Result<StudentEnrollmentResponse>.Failure("Student not found", StatusCodes.Status400BadRequest);
            }

            if(!await academicYearRepository.IsExists(x=> x.Id == model.AcademicYearId))
            {
                return Result<StudentEnrollmentResponse>.Failure("Academic Year not found", StatusCodes.Status400BadRequest);
            }

            if(!await sectionRepository.IsExists(x=> x.Id == model.SectionId))
            {
                return Result<StudentEnrollmentResponse>.Failure("Section not found", StatusCodes.Status400BadRequest);
            }

            if(await studentEnrollmentRepository.IsExists(x=> x.StudentId == model.StudentId && x.AcademicYearId == model.AcademicYearId))
            {
                return Result<StudentEnrollmentResponse>.Failure("Student is already enrolled for this academic year", StatusCodes.Status400BadRequest);
            }

            var enrollment = new StudentEnrollment(
                model.StudentId,
                model.SectionId,
                model.AcademicYearId
            );
            await studentEnrollmentRepository.AddAsync(enrollment);
            var returnvalue = await unitOfWork.SaveChangesAsync();
            if(returnvalue > 0)
            {
              var response = new StudentEnrollmentResponse
              {
                 Id = enrollment.Id                 
              };
                return Result<StudentEnrollmentResponse>.Success(response, StatusCodes.Status201Created, "Student enrolled successfully");
            }
            return Result<StudentEnrollmentResponse>.Failure("Failed to enroll student", StatusCodes.Status500InternalServerError);

        }

        public async Task<Result<List<StudentEnrollmentResponse>>> GetEnrollments()
        {
            var result = await studentEnrollmentRepository.GetEnrollments();
            if(result.Count ==0)
            {
                return Result<List<StudentEnrollmentResponse>>.Failure("No enrollments found", StatusCodes.Status200OK);

            }
            return Result<List<StudentEnrollmentResponse>>.Success(result, StatusCodes.Status200OK, "Enrollments Fetched Successfully");
        }
    }
}
