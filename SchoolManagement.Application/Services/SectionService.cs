using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.Section;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public class SectionService(ISectionRepository sectionRepository,
        ISchoolClassRepository schoolClassRepository,
        IUnitOfWork unitOfWork) : ISectionService
    {
        public async Task<Result<SectionResponse>> CreateSection(SectionRequest request)
        {
            if (!await schoolClassRepository.IsExists(x => x.Id == request.SchoolClassId)){
                return Result<SectionResponse>.Failure("School class not found", StatusCodes.Status404NotFound);
            }
            if (await sectionRepository.IsExists(x => x.Name == request.Name && x.SchoolClassId == request.SchoolClassId))
            {
                return Result<SectionResponse>.Failure("Section with the same name already exists in this class", StatusCodes.Status400BadRequest);
            }

            var section = new Section(
                request.Name,
                request.SchoolClassId
                );
            await sectionRepository.AddAsync(section);
            var returnValue = await unitOfWork.SaveChangesAsync();
            if (returnValue > 0)
            {
                var response = new SectionResponse
                {
                    Id = section.Id,
                    Name = section.Name,
                    SchoolClassId = section.SchoolClassId,
                    SchoolClassName = ""
                };
                return Result<SectionResponse>.Success(response, StatusCodes.Status201Created, "Section created successfully");
            }
            return Result<SectionResponse>.Failure("Failed to create section", StatusCodes.Status500InternalServerError);

        }

        public async Task<Result<List<SectionResponse>>> GetSections()
        {
            var result = await sectionRepository.GetSections();
            if (result == null)
            {
                return Result<List<SectionResponse>>.Failure("No sections found", StatusCodes.Status404NotFound);
            }
           
            return Result<List<SectionResponse>>.Success(result, StatusCodes.Status200OK, "Sections fetched successfully");
        }
    }
}
