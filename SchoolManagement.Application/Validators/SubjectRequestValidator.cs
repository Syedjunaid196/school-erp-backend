using FluentValidation;
using SchoolManagement.Application.RR_Models.Subject;

namespace SchoolManagement.Application.Validators
{
    public class SubjectRequestValidator : AbstractValidator<SubjectRequest>
    {
        public SubjectRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Subject name is required.")
                .MaximumLength(100).WithMessage("Subject name cannot exceed 100 characters.");
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Subject code is required.")
                .MaximumLength(20).WithMessage("Subject code cannot exceed 20 characters.");
        }
    }
}
