using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class Section : BaseEntity
    {
        private Section() { }

        public string Name { get; private set; } = null!;
        public Guid SchoolClassId { get; private set; }
        public SchoolClass SchoolClass { get; private set; } = null!;

        public Section(string name, Guid schoolClassId)
        {
            Name = name;
            SchoolClassId = schoolClassId;
        }
    }
}
