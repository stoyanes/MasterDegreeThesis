﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Model
{
    /*
        We need a way to identify traditionally non-working day to working day.
        For example sometimes Saturdays are working days.
    */
    public class AdditionalWorkingDay
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime WorkingDate { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
