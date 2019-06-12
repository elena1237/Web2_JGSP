using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WebApp.Models;
using WebApp.Persistence;
using WebApp.Persistence.Repository;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    [RoutePrefix("Api/Passengers")]
    public class PassengersController : ApiController
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public IUnitOfWork db { get; set; }

        public PassengersController(IUnitOfWork db)
        {
            this.db = db;
        }

        // GET: api/Passengers
        public IEnumerable<Passenger> GetUsers()
        {
            return db.Passengers.GetAll();
        }

        // GET: api/Passengers/5
        [ResponseType(typeof(Passenger))]
        [Route("GetById/{id}")]
        public IHttpActionResult GetPassenger(int id)
        {
            Passenger passenger = db.Passengers.Get(id);
            if (passenger == null)
            {
                return NotFound();
            }

            return Ok(passenger);
        }

        // PUT: api/Passengers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPassenger(string id, Passenger passenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passenger.Id)
            {
                return BadRequest();
            }

            db.Passengers.Update(passenger);

            try
            {
                db.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Passengers
        [AllowAnonymous]
        [ResponseType(typeof(Passenger))]
        [Route("InsertPassenger")]

        public IHttpActionResult PostPassenger([FromBody]Passenger passenger)
        {
            ApplicationDbContext context = new ApplicationDbContext();
          PassengerType pt =  db.PassengerTypes.GetAll().FirstOrDefault(x => x.Name == passenger.PassengerType.Name);
          passenger.PassengerType = pt;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var user = new Passenger() { UserName = passenger.Email, Email = passenger.Email, PasswordHash = ApplicationUser.HashPassword(passenger.Password), Password = ApplicationUser.HashPassword(passenger.Password), FirstName = passenger.FirstName, LastName = passenger.LastName, BirthDate = passenger.BirthDate, Address = passenger.Address, Approved = passenger.Approved, Role = "AppUser"};
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
        
            if (passenger.Role == "AppUser")
            {
                var user = new Passenger() { UserName = passenger.Email, Email = passenger.Email, PasswordHash = ApplicationUser.HashPassword(passenger.Password), Password = ApplicationUser.HashPassword(passenger.Password), FirstName = passenger.FirstName, LastName = passenger.LastName, BirthDate = passenger.BirthDate, Address = passenger.Address, Approved = passenger.Approved, Role = "AppUser" };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }
           // db.Passengers.Add(user);
  

            try
            {
                db.Complete();
            }
            catch (DbUpdateException)
            {
                if (PassengerExists(passenger.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //passenger.PasswordHash = passenger.Password.GetHashCode();

            return CreatedAtRoute("DefaultApi", new { controller = "passenger", id = passenger.Id }, passenger);
        }

        // DELETE: api/Passengers/5
        [ResponseType(typeof(Passenger))]
        public IHttpActionResult DeletePassenger(int id)
        {
            Passenger passenger = db.Passengers.Get(id);
            if (passenger == null)
            {
                return NotFound();
            }

            db.Passengers.Remove(passenger);
            db.Complete();

            return Ok(passenger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PassengerExists(string id)
        {
            return db.Passengers.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}