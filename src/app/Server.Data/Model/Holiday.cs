using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Model
{

    // here we will store all non-woring official days
    public class Holiday
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Range(1970, 2099)]
        public int ForYear { get; set; }

        public DateTime HolidayDate { get; set; }
    }
}
