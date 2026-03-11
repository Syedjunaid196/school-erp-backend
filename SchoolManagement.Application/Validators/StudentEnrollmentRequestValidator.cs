using FluentValidation;
using SchoolManagement.Application.RR_Models.StudentEnrollment;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Validators
{
    public class StudentEnrollmentRequestValidator: AbstractValidator<StudentEnrollmentRequest>
    {
        public StudentEnrollmentRequestValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("StudentId is required.")
                .Must(id => id != Guid.Empty).WithMessage("StudentId must be a valid GUID.");

            RuleFor(x => x.AcademicYearId)
                .NotEmpty().WithMessage("AcademicYearId is required.")
                .Must(id => id != Guid.Empty).WithMessage("AcademicYearId must be a valid GUID.");

            RuleFor(x => x.SectionId)
                .NotEmpty().WithMessage("SectionId is required.")
                .Must(id => id != Guid.Empty).WithMessage("SectionId must be a valid GUID.");
        }
    }
}
