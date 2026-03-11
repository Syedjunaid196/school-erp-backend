using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.RR_Models.AcademicYear
{
    public class AcademicYearRequest
    {
        public string Name { get; set; } = null!;
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }

    }
}
