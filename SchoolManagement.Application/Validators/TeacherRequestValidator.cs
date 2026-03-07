using FluentValidation;
using SchoolManagement.Application.RR_Models.Teacher;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Validators
{
    public class TeacherRequestValidator : AbstractValidator<TeacherRequest>
    {
        public TeacherRequestValidator()
        {
            RuleFor(t => t.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(t => t.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(t => t.Gender)
                 .IsInEnum()
                 .NotEqual(Gender.unknown).WithMessage("Gender must be selected");
            RuleFor(t => t.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(t => t.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(t => t.EmployeeCode)
                .Length(5, 20).WithMessage("Employee code must be between 5 and 20 characters.");
            RuleFor(t => t.DateOfJoining)
                .NotEmpty().WithMessage("Date of Joining is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Date of Joining cannot be in the future.");
        }
    }
}
