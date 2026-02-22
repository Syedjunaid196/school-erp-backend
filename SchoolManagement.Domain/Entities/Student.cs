using SchoolManagement.Domain.common;

namespace SchoolManagement.Domain.Entities
{
    public class Student : BaseEntity
    {
        private Student() { }

        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;

        public string RollNumber { get; private set; } = null!;
        public DateTime DateOfBirth { get; private set; }

        //parent-relationship

        public Guid? ParentId { get; private set;  }
        public Parent? Parent { get; private set; }

        public Student(Guid userId, string rollNumber, DateTime dateOfBirth, Guid? parentId = null)
        {
            UserId = userId;
            RollNumber = rollNumber;
            DateOfBirth = dateOfBirth;
            ParentId = parentId;
        }
    }
}
