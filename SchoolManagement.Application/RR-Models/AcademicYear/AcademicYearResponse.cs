using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.RR_Models.AcademicYear
{
    public class AcademicYearResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
