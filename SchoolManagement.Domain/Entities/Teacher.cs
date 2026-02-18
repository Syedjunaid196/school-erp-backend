using SchoolManagement.Domain.common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public Guid UserId { get; private set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; private set; } = null!;

        public string EmployeeCode { get; private set; } = null!;

        public DateTime DateOfJoining { get; private set; }

        public Teacher(Guid userId, string employeeCode, DateTime dateOfJoining)
        {
            UserId = userId;
            EmployeeCode = employeeCode;
            DateOfJoining = dateOfJoining;
        }
    }
}
