using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class BaseTicket
    {
        public int Id { get; set; }

        public bool IsValid { get; set; }
        [Required]
        [StringLength(20)]
        public string TimeIssued { get; set; }
    }
}