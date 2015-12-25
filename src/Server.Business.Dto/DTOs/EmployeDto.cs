using Server.Data.Model;
using System.Collections.Generic;

namespace Server.Business.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public IList<VacationRequest> Requests { get; set; }

        public IList<LeaveDays> LeaveDays { get; set; }

        public Employee Manager { get; set; }
    }
}
