using Server.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Server.Business.Dto
{
    [MetadataType(typeof(LeaveDays))]
    public class LeaveDaysDto
    {
        public int EmployeeID { get; set; }

        public int ForYear { get; set; }

        public int AllowedPaidDays { get; set; }

        public int TakenPaidDays { get; set; }

        public int AllowedNonPaidDays { get; set; }

        public int TakenNonPaidDays { get; set; }

        public int SickDays { get; set; }

        public int TransferredDays { get; set; }

        public int CompensationDays { get; set; }
    }
}
