using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class SchoolClass : BaseEntity
    {
        private SchoolClass() { }

        public string Name { get; private set; } = null!;

        public SchoolClass(string name)
        {
            Name = name;
        }
    }
}
