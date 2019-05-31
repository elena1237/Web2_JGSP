using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Passenger : ApplicationUser
    {
        //public int Id { get; set; }
        public bool Approved { get; set; }
        public PassengerType PassengerType { get; set; }
        public string ImageUrl { get; set; }
    }
}