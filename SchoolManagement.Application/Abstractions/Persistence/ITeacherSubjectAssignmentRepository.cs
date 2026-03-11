using SchoolManagement.Application.RR_Models.TeacherSubjectAssignment;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface ITeacherSubjectAssignmentRepository: IBaseRepository<TeacherSubjectAssignment>
    {
        Task<List<TeacherSubjectAssignmentResponse>> GetAssignments();
    }
}
