using SchoolManagement.Application.RR_Models.TeacherSubjectAssignment;
using SchoolManagement.Application.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Abstractions.Services
{
    public interface ITeacherSubjectAssignmentService
    {
        public Task<Result<TeacherSubjectAssignmentResponse>> AssignTeacher(TeacherSubjectAssignmentRequest model);

        public Task<Result<List<TeacherSubjectAssignmentResponse>>> GetAllAssignments();
    }
}
