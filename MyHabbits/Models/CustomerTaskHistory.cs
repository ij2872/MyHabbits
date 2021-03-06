﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHabbits.Models
{
    public class CustomerTaskHistory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int task_id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? completed_date { get; set; }

        public TimeSpan time_completed { get; set; }
        public TimeSpan time_goal { get; set; }
        public Boolean is_done { get; set; }
        public Decimal? percent_completed { get; set; }
        
        [Required]
        public string ApplicationUserId { get; set; }

    }
}