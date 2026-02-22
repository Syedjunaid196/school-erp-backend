using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class Parent : BaseEntity
    {
        private Parent() { }

        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;

        public string Occupation { get; private set; } = null!;
        public string Address { get; private set; } = null!;

        public ICollection<Student> Students { get; private set; } = new List<Student>();

        public Parent(Guid userId, string occupation, string address)
        {
            UserId = userId;
            Occupation = occupation;
            Address = address;
        }
    }
}
