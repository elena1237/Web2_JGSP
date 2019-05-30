﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Line
    {
        public int Id{ get; set; }

        [Required]
        [Range(1, 100)]
        public int LineNumber { get; set; }
        public List<Station> Stations { get; set; }


    }
}