using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class Subject : BaseEntity
    {
        private Subject() { }

        public string Name { get; private set; } = null!;
        public string Code { get; private set; } = null!;

        public Subject(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
