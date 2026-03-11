namespace SchoolManagement.Application.RR_Models.StudentEnrollment
{
    public class StudentEnrollmentResponse
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; } = null!;

        public string AcademicYearName { get; set; } = null!;
        public string ClassName { get; set; } = null!;
        public string SectionName { get; set; } = null!;
    }
}
