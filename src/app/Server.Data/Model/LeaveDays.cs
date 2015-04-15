using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{
    public class LeaveDays
    {
        public int ID { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public int ForYear { get; set; }

        public int AllowedPaidDays { get; set; }

        public int TakenPaidDays { get; set; }

        public int AllowedNonPaidDays { get; set; }

        public int TakenNonPaidDays { get; set; }

        public int SickDays { get; set; }
    }
}
