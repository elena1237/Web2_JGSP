using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Station
    {
        [Required]
        public double X { get; set; }

        [Required]
        public double Y { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string Adress { get; set; }
        public List<Line> Lines { get; set; }

    }
}