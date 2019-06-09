﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public string DayInWeek { get; set; } 
        public int ScheduleTypeId { get; set; }
        //public ScheduleType ScheduleType { get; set; }
        public int LineId { get; set; }
        public Line Line { get; set; }


        //public Schedule(int id,string dep,int lineid)
        //{
        //    Id = id;
        //    Departure = dep;
        //    LineId = lineid;
        //}
    }
}