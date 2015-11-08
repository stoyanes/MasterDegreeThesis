using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public DateTime HolidayDate { get; set; }
        
        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
