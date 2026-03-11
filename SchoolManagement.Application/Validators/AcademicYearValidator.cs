using FluentValidation;
using SchoolManagement.Application.RR_Models.AcademicYear;

namespace SchoolManagement.Application.Validators
{
    public class AcademicYearValidator : AbstractValidator<AcademicYearRequest>
    {
        public AcademicYearValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Academic year name is required.")
                 .MinimumLength(3).WithMessage("Academic year name must be at least 3 characters.")
                 .MaximumLength(50).WithMessage("Academic year name cannot exceed 50 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date must be greater than start date.");
        }
    }
}
