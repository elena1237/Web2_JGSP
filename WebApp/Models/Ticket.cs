using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType TicketType { get; set; }

        public Passenger Passenger { get; set; }
        public bool IsValid { get; set; }
        [Required]
        [StringLength(20)]
        public string TimeIssued { get; set; }


    }
}