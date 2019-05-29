using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public List<Ticket> Tickets { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        [Range(0, 15000)]
        public float TicketPrice { get; set; }
        fdfd
    }
}