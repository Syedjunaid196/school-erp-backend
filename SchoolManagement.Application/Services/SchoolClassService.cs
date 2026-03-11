using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.SchoolClass;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public class SchoolClassService(ISchoolClassRepository schoolClassRepository,
        IUnitOfWork unitOfWork) : ISchoolClassService
    {
        public async Task<Result<SchoolClassResponse>> CreateSchoolClass(SchoolClassRequest model)
        {
           
            if (await schoolClassRepository.IsExists(x => x.Name.ToLower()== model.Name.ToLower())) 
            {
                return Result<SchoolClassResponse>.Failure("Class with the same name already exists", StatusCodes.Status400BadRequest);
            }
            var schoolClass = new SchoolClass(model.Name);
            await schoolClassRepository.AddAsync(schoolClass);
            var returnValue = await unitOfWork.SaveChangesAsync();
            if (returnValue > 0)
            {
                var response = new SchoolClassResponse
                {
                    Id = schoolClass.Id,
                    Name = schoolClass.Name
                };
                return Result<SchoolClassResponse>.Success(response, StatusCodes.Status201Created, "Class created successfully");
            }
            return Result<SchoolClassResponse>.Failure("Failed to create  class", StatusCodes.Status500InternalServerError);

        }

        public async Task<Result<List<SchoolClassResponse>>> GetSchoolClasses()
        {
            var result = await schoolClassRepository.GetSchoolClasses();
            if (result.Count == 0)
            {
                return Result<List<SchoolClassResponse>>.Failure("No school classes found", 404);
            }
            return Result<List<SchoolClassResponse>>.Success(result, StatusCodes.Status200OK, "School classes fetched successfully");
        }
    }
}
