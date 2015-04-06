using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{
    public class EmployeeLeaveDays
    {
        public int ID { get; set; }

        public int ForYear { get; set; }

        public int AllowedPaidDays { get; set; }

        public int TakenPaidDays { get; set; }

        public int AllowedNonPaidDays { get; set; }

        public int TakenNonPaidDays { get; set; }

        public int SickDays { get; set; }
    }
}
