using Server.Data.Enums;
using Server.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.Model
{
    public class VacationRequest : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public RequestStates Status { get; set; }

        [Required]
        public VacationType VacationType { get; set; }
    }
}
