namespace SchoolManagement.Application.RR_Models.Section
{
    public class SectionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public Guid SchoolClassId { get; set; }
        public string SchoolClassName { get; set; } = null!;
    }
}
