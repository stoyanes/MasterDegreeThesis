using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{
    public class LeaveDays
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        [Range(1970, 2099)]
        public int ForYear { get; set; }

        [Required]
        [Range(0, 100)]
        public int AllowedPaidDays { get; set; }

        [Required]
        [Range(0, 100)]
        public int TakenPaidDays { get; set; }

        [Required]
        [Range(0, 100)]
        public int AllowedNonPaidDays { get; set; }

        [Required]
        [Range(0, 100)]
        public int TakenNonPaidDays { get; set; }

        [Required]
        [Range(0, 100)]
        public int SickDays { get; set; }
    }
}
