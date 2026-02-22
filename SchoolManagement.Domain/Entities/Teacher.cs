using SchoolManagement.Domain.common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        private Teacher() { }

        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;

        public string EmployeeCode { get; private set; } = null!;
        public DateTime JoiningDate { get; private set; }

        public Teacher(Guid userId, string employeeCode, DateTime joiningDate)
        {
            UserId = userId;
            EmployeeCode = employeeCode;
            JoiningDate = joiningDate;
        }
    }
}
