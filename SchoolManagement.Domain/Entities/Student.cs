using SchoolManagement.Domain.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolManagement.Domain.Entities
{
    public class Student: BaseEntity
    {


        public Guid UserId { get; private set; }

        [ForeignKey("UserId")]
        public User User { get; private set; } =null!;

        public string RollNumber { get; private set; } = null!;

        public DateTime DateOfBirth { get; private set; }

        public Student(Guid userid, string rollNumber, DateTime dateOfBirth)
        {
            UserId = userid;
            RollNumber = rollNumber;
            DateOfBirth = dateOfBirth;
        }




    }
}
