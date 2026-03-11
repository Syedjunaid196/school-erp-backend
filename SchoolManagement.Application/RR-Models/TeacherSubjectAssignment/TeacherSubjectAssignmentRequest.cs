using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.RR_Models.TeacherSubjectAssignment
{
    public class TeacherSubjectAssignmentRequest
    {
        public Guid TeacherId { get; set; }

        public Guid SubjectId { get; set; }

        public Guid SectionId { get; set; }
    }
}