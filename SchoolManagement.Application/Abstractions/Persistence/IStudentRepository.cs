using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Abstractions.Persistence
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
    }
}
