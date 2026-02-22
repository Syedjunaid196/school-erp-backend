using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class AcademicYear : BaseEntity
    {
        private AcademicYear() { }

        public string Name { get; private set; } = null!;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public AcademicYear(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
