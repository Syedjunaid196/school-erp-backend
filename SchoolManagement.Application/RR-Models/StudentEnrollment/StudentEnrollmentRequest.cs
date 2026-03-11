namespace SchoolManagement.Application.RR_Models.StudentEnrollment
{
    public class StudentEnrollmentRequest
    {
        public Guid StudentId { get; set; }
        public Guid AcademicYearId { get; set; }
        public Guid SectionId { get; set; }

    }
}
