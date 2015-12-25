using Server.Data.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Business.Dto
{
    [MetadataType(typeof(Holiday))]
    public class HolidayDto
    {
        public DateTime WorkingDate { get; set; }
        public string Description { get; set; }
    }
}
