using FluentValidation;
using SchoolManagement.Application.RR_Models.Section;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Validators
{
    public class SectionRequestValidator: AbstractValidator<SectionRequest>
    {
        public SectionRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Section name is requireddd.")
                .MaximumLength(20).WithMessage("Section name must not exceed 20 characters.");

            RuleFor(x => x.SchoolClassId)
                .NotEmpty().WithMessage("School class ID is required.")
                .Must(id => id != Guid.Empty).WithMessage("School class ID must be a valid GUIDddd.");
        }
    }
}
