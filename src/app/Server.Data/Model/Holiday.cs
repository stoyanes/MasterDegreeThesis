using Server.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Model
{

    // here we will store all non-woring official days
    public class Holiday : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime HolidayDate { get; set; }
        
        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
