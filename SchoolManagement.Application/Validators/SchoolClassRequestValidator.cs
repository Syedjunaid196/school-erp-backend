using FluentValidation;
using SchoolManagement.Application.RR_Models.SchoolClass;

namespace SchoolManagement.Application.Validators
{
    public class SchoolClassRequestValidator : AbstractValidator<SchoolClassRequest>
    {
        public SchoolClassRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .NotNull().WithMessage("Name cannot be null.")
                .MinimumLength(1).WithMessage("Name must be at least 1 characters long.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Name can only contain letters, numbers, and spaces.");
        }
    }
}
