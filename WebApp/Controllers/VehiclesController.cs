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
using WebApp.Models;

namespace WebApp.Controllers
{
    public class VehiclesController : ApiController
    {
        private WebAppContext db = new WebAppContext();

        // GET: api/Vehicles
        public IQueryable<Vehicles> GetVehicles()
        {
            return db.Vehicles;
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicles))]
        public IHttpActionResult GetVehicles(int id)
        {
            Vehicles vehicles = db.Vehicles.Find(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return Ok(vehicles);
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicles(int id, Vehicles vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicles.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiclesExists(id))
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

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicles))]
        public IHttpActionResult PostVehicles(Vehicles vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehicles.Add(vehicles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicles.Id }, vehicles);
        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicles))]
        public IHttpActionResult DeleteVehicles(int id)
        {
            Vehicles vehicles = db.Vehicles.Find(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            db.Vehicles.Remove(vehicles);
            db.SaveChanges();

            return Ok(vehicles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehiclesExists(int id)
        {
            return db.Vehicles.Count(e => e.Id == id) > 0;
        }
    }
}