using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{

    // here we will store all non-woring official days
    public class Holiday
    {
        public int ID { get; set; }

        public int ForYear { get; set; }

        public DateTime HolidayDate { get; set; }
    }
}
