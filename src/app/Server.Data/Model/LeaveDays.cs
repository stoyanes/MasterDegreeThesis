using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.Model
{
    public class LeaveDays
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

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

        [Required]
        [Range(0, 10)]
        public int TransferredDays { get; set; }

        [Required]
        [Range(0, 100)]
        public int CompensationDays { get; set; }
    }
}
