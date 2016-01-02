using System;

namespace Server.Business.Dto
{
    public class AdditionalWorkingDayDto
    {
        public int Id { get; set; }

        public DateTime WorkingDate { get; set; }

        public string Description { get; set; }
    }
}
