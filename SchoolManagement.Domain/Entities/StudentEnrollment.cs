using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class StudentEnrollment : BaseEntity
    {
        private StudentEnrollment() { }

        public Guid StudentId { get; private set; }
        public Student Student { get; private set; } = null!;

        public Guid SectionId { get; private set; }
        public Section Section { get; private set; } = null!;

        public Guid AcademicYearId { get; private set; }
        public AcademicYear AcademicYear { get; private set; } = null!;

        public StudentEnrollment(Guid studentId, Guid sectionId, Guid academicYearId)
        {
            StudentId = studentId;
            SectionId = sectionId;
            AcademicYearId = academicYearId;
        }
    }
}
