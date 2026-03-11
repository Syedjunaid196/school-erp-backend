using SchoolManagement.Application.RR_Models.Subject;
using SchoolManagement.Application.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface ISubjectService
    {
        Task<Result<SubjectResponse>> CreateSubject(SubjectRequest model);
        Task<Result<List<SubjectResponse>>> GetAllSubjects();
    }
}
