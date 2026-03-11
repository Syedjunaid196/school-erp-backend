using FluentValidation;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Validators
{
    public class TeacherSubjectAssignmentRequestValidator: AbstractValidator<TeacherSubjectAssignment>
    {
        public TeacherSubjectAssignmentRequestValidator()
        {
            RuleFor(x => x.TeacherId)
                .NotEmpty().WithMessage("TeacherId is required.")
                .NotEqual(Guid.Empty).WithMessage("TeacherId cannot be an empty GUID.");

            RuleFor(x => x.SubjectId)
                .NotEmpty().WithMessage("SubjectId is required.")
                .NotEqual(Guid.Empty).WithMessage("SubjectId cannot be an empty GUID.");

            RuleFor(x => x.SectionId)
                .NotEmpty().WithMessage("SectionId is required.")
                .NotEqual(Guid.Empty).WithMessage("SectionId cannot be an empty GUID.");
        }
    }
}
