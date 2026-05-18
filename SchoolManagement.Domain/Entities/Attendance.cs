using SchoolManagement.Domain.common;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        private Attendance()
        {

        }

        public Guid StudentEnrollmentId { get; private set; }

        public StudentEnrollment StudentEnrollment { get; private set; } = null!; //navigation prop

        public DateOnly Date { get; private set; }
        public AttendanceStatus AttendanceStatus { get; private set; }

        public Attendance(Guid studentenrollmentId, DateOnly date, AttendanceStatus attendanceStatus)
        {
            StudentEnrollmentId = studentenrollmentId;
            Date = date;
            AttendanceStatus = attendanceStatus;
        }

        public void UpdateStatus(AttendanceStatus attendanceStatus)
        {
            AttendanceStatus = attendanceStatus;
        }


    }
}
