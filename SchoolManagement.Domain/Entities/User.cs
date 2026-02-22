using SchoolManagement.Domain.common;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        private User() { } //for ef core

        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Email { get; private set; } = null!;

        public string HasPassword { get; private set; } = null!;



        public Gender Gender { get; private set; }

        public UserRole Role { get; private set; }

        public UserStatus Status { get; private set; }

        public User(string firstName, string lastName, string email, string hashpassword, Gender gender, UserRole role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HasPassword = hashpassword;
            Gender = gender;
            Role = role;
            Status = UserStatus.Active;
        }

        public void Deactivate()
        {
            Status = UserStatus.Inactive;
            MarkUpdated();
        }


    }
}
