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
    public class TicketTypesController : ApiController
    {
        private WebAppContext db = new WebAppContext();

        // GET: api/TicketTypes
        public IQueryable<TicketType> GetTicketTypes()
        {
            return db.TicketTypes;
        }

        // GET: api/TicketTypes/5
        [ResponseType(typeof(TicketType))]
        public IHttpActionResult GetTicketType(int id)
        {
            TicketType ticketType = db.TicketTypes.Find(id);
            if (ticketType == null)
            {
                return NotFound();
            }

            return Ok(ticketType);
        }

        // PUT: api/TicketTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicketType(int id, TicketType ticketType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketType.Id)
            {
                return BadRequest();
            }

            db.Entry(ticketType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketTypeExists(id))
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

        // POST: api/TicketTypes
        [ResponseType(typeof(TicketType))]
        public IHttpActionResult PostTicketType(TicketType ticketType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketTypes.Add(ticketType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ticketType.Id }, ticketType);
        }

        // DELETE: api/TicketTypes/5
        [ResponseType(typeof(TicketType))]
        public IHttpActionResult DeleteTicketType(int id)
        {
            TicketType ticketType = db.TicketTypes.Find(id);
            if (ticketType == null)
            {
                return NotFound();
            }

            db.TicketTypes.Remove(ticketType);
            db.SaveChanges();

            return Ok(ticketType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketTypeExists(int id)
        {
            return db.TicketTypes.Count(e => e.Id == id) > 0;
        }
    }
}