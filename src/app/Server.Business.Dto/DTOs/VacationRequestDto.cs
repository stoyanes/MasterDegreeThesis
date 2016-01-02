using Server.Data.Enums;
using System;

namespace Server.Business.Dto
{
    public class VacationRequestDto
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public RequestStates Status { get; set; }

        public VacationType VacationType { get; set; }
    }
}
