namespace SchoolManagement.Application.RR_Models.TeacherSubjectAssignment
{
    public class TeacherSubjectAssignmentResponse
    {
        public Guid Id {  get; set; }
        public string TeacherName { get; set; } = null!;
        public string SubjectName { get; set; } = null!;

        public string ClassName { get; set; } = null!;
        public string SectionName { get; set; } = null!;

    }
}