using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.AcademicYear;
using SchoolManagement.Application.Utils;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public class AcademicYearService(IAcademicYearRepository academicYearRepository,
        IUnitOfWork unitOfWork) : IAcademicYearService
    {
        public async Task<Result<AcademicYearResponse>> CreateAcademicYear(AcademicYearRequest model)
        {

            var exists = await academicYearRepository.IsExists(x => x.Name == model.Name);
            if (exists)
            {
                return Result<AcademicYearResponse>.Failure("An academic year with the same name already exists", StatusCodes.Status400BadRequest);
            }

            var academicYear = new AcademicYear(
                model.Name,
                model.StartDate,
                model.EndDate
            );
            await academicYearRepository.AddAsync(academicYear);
            var returnval = await unitOfWork.SaveChangesAsync();
            if (returnval > 0)
            {
                var response = new AcademicYearResponse
                {
                    Id = academicYear.Id,
                    Name = academicYear.Name,
                    StartDate = academicYear.StartDate,
                    EndDate = academicYear.EndDate
                };
                return Result<AcademicYearResponse>.Success(response, StatusCodes.Status201Created, "Academic year created successfully");
            }
            return Result<AcademicYearResponse>.Failure("Failed to create academic year", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<List<AcademicYearResponse>>> GetAcademicYears()
        {
            var result = await academicYearRepository.GetAcademicYears();
            if (result.Count > 0)
            {
                return Result<List<AcademicYearResponse>>.Success(result, StatusCodes.Status200OK, "Academic years fetched successfully");
            }
            return Result<List<AcademicYearResponse>>.Failure("No academic years found", StatusCodes.Status404NotFound);


        }
    }
}
