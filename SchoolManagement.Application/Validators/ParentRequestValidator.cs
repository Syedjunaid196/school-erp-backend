using FluentValidation;
using SchoolManagement.Application.RR_Models.Parent;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Validators
{
    public class ParentRequestValidator : AbstractValidator<ParentRequest>
    {
        public ParentRequestValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(p => p.Gender)
                .NotEqual(Gender.unknown).WithMessage("Gender must be selected");

            RuleFor(p => p.Occupation)
                .NotEmpty().WithMessage("Occupation is required.")
                .MaximumLength(100).WithMessage("Occupation cannot exceed 100 characters.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");
        }
    }
}
