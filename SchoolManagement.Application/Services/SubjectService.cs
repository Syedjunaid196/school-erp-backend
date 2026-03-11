using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Subject;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Services
{
    public class SubjectService(ISubjectRepository subjectRepository,
        IUnitOfWork unitOfWork) : ISubjectService
    {
        public async Task<Result<SubjectResponse>> CreateSubject(SubjectRequest model)
        {
            if (await subjectRepository.IsExists(x => x.Name == model.Name))
            {
                return Result<SubjectResponse>.Failure("Subject with the same name already exists", StatusCodes.Status400BadRequest);
            }
            if (await subjectRepository.IsExists(x => x.Code == model.Code))
            {
                return Result<SubjectResponse>.Failure("Subject with the same code already exists", StatusCodes.Status400BadRequest);
            }

            var subject = new Subject(model.Name, model.Code);
            await subjectRepository.AddAsync(subject);
            var returnValue = await unitOfWork.SaveChangesAsync();
            if (returnValue > 0)
            {
                var subjectResponse = new SubjectResponse
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Code = subject.Code
                };
                return Result<SubjectResponse>.Success(subjectResponse, StatusCodes.Status201Created, "Subject created successfully");
            }
            return Result<SubjectResponse>.Failure("Failed to create subject", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<List<SubjectResponse>>> GetAllSubjects()
        {
            var result = await subjectRepository.GetAllSubjects();
            if (result == null || result.Count == 0)
            {
                return Result<List<SubjectResponse>>.Failure("No subjects found", StatusCodes.Status404NotFound);
            }
            return Result<List<SubjectResponse>>.Success(result, StatusCodes.Status200OK, "Subjects fetched successfully");
        }
    }
}
