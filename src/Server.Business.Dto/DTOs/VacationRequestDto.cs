using Server.Data.Enums;
using Server.Data.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Business.Dto
{
    [MetadataType(typeof(VacationRequest))]
    public class VacationRequestDto
    {
        public int EmployeeID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public RequestStates Status { get; set; }

        public VacationType VacationType { get; set; }
    }
}
