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

        [Required]
        public string Password { get; set; }

        //public Passenger(string firstname, string lastname, string adress, string role, string birthdate, bool app,PassengerType pt,string img,string usrname,bool appr,string em)
        //{
        //    FirstName = firstname;
        //    LastName = lastname;
        //    Address = adress;
        //    Role = role;
        //    BirthDate = birthdate;
        //    Approved = app;
        //    PassengerType = pt;
        //    ImageUrl = img;
        //    UserName = usrname;
        //    Approved = appr;
        //    Email = em;
            


        //}
    }
}