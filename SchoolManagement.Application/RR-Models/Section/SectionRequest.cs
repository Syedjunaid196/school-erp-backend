namespace SchoolManagement.Application.RR_Models.Section
{
    public class SectionRequest
    {
        public string Name { get; set; } = null!;
        public Guid SchoolClassId { get; set; }

    }
}
