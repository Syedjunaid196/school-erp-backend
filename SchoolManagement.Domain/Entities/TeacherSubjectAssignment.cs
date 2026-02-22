using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class TeacherSubjectAssignment : BaseEntity
    {
        private TeacherSubjectAssignment() { }

        public Guid TeacherId { get; private set; }
        public Teacher Teacher { get; private set; } = null!;

        public Guid SubjectId { get; private set; }
        public Subject Subject { get; private set; } = null!;

        public Guid SectionId { get; private set; }
        public Section Section { get; private set; } = null!;

        public TeacherSubjectAssignment(Guid teacherId, Guid subjectId, Guid sectionId)
        {
            TeacherId = teacherId;
            SubjectId = subjectId;
            SectionId = sectionId;
        }
    }
}
