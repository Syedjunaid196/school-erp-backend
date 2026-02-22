using FluentValidation;
using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.Validators
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(s => s.Gender)
                .IsInEnum()
                .NotEqual(Gender.unknown).WithMessage("Gender must be selected");
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(s => s.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(s => s.RollNumber)
                .NotEmpty().WithMessage("Roll number is Required")
                .MaximumLength(50).WithMessage("Roll number cannot exceed 50 characters.");
            RuleFor(s => s.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .LessThan(DateTime.Today.AddYears(-3)).WithMessage("Student must be at least 3 years old.");
            RuleFor(s => s.ParenetId)
                .Must(id=> id == null || id != Guid.Empty).WithMessage("Parent ID must be a valid GUID or null.");
        }
    }
}
