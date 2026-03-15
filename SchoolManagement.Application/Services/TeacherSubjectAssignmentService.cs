using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.TeacherSubjectAssignment;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public class TeacherSubjectAssignmentService(ITeacherSubjectAssignmentRepository teacherSubjectAssignmentRepository,
        ITeacherRepository teacherRepository,
        ISubjectRepository subjectRepository,
        ISectionRepository sectionRepository,
        IUnitOfWork unitOfWork) : ITeacherSubjectAssignmentService
    {
        public async Task<Result<TeacherSubjectAssignmentResponse>> AssignTeacher(TeacherSubjectAssignmentRequest model)
        {
            if(!await teacherRepository.IsExists(x=> x.Id == model.TeacherId))
            {
                return Result<TeacherSubjectAssignmentResponse>.Failure("Teacher not found", StatusCodes.Status400BadRequest);
            }
            if(!await subjectRepository.IsExists(x=> x.Id == model.SubjectId)){
                return Result<TeacherSubjectAssignmentResponse>.Failure("Subject not found", StatusCodes.Status400BadRequest);
            }
            if(!await sectionRepository.IsExists(x=> x.Id == model.SectionId)){
                return Result<TeacherSubjectAssignmentResponse>.Failure("Section not found", StatusCodes.Status400BadRequest);
            }
            if(await teacherSubjectAssignmentRepository.IsExists(x=> x.TeacherId == model.TeacherId && x.SubjectId == model.SubjectId && x.SectionId == model.SectionId))
            {
                return Result<TeacherSubjectAssignmentResponse>.Failure("This assignment already exists", StatusCodes.Status400BadRequest);
            }
            var assignments = new TeacherSubjectAssignment(
                model.TeacherId,
                model.SubjectId,
                model.SectionId
                );
            await teacherSubjectAssignmentRepository.AddAsync(assignments);
            var returnValue = await unitOfWork.SaveChangesAsync();
            if(returnValue>0 )
            {
                var response = new TeacherSubjectAssignmentResponse
                {
                    Id = assignments.Id
                };
                return Result<TeacherSubjectAssignmentResponse>.Success(response, StatusCodes.Status201Created, "Teacher assigned successfully");
            }
            return Result<TeacherSubjectAssignmentResponse>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<List<TeacherSubjectAssignmentResponse>>> GetAllAssignments()
        {
            var result = await teacherSubjectAssignmentRepository.GetAssignments();
            if(result.Count>0)
            {
                return Result<List<TeacherSubjectAssignmentResponse>>.Success(result, StatusCodes.Status200OK, "Assignments fetched successfully");
            }
            return Result<List<TeacherSubjectAssignmentResponse>>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);
        }
    }
}
