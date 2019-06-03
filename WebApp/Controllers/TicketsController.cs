using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    [RoutePrefix("Api/ticket")]
    public class TicketsController : ApiController
    {
      
            private IUnitOfWork db;

            public TicketsController(IUnitOfWork db)
            {
                this.db = db;
            }

        // GET: api/Tickets
        [HttpGet]
        [Route("AllTicket")]
        public IEnumerable<Ticket> GetTickets()
            {
                return db.Tickets.GetAll();
            }
        
        [HttpGet]
        [Route("GetById")]
            // GET: api/Tickets/5
            [ResponseType(typeof(Ticket))]
            public IHttpActionResult GetTicket(int id)
            {
                Ticket ticket = db.Tickets.Get(id);
                if (ticket == null)
                {
                    return NotFound();
                }

                return Ok(ticket);
            }

        // PUT: api/Tickets/5
        [HttpPut]
        [Route("UpdateTicket")]
        [ResponseType(typeof(void))]
            public IHttpActionResult PutTicket(int id, Ticket ticket)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != ticket.Id)
                {
                    return BadRequest();
                }

                db.Tickets.Update(ticket);

                try
                {
                    db.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(id))
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

        // POST: api/Tickets
        [HttpPost]
        [Route("InsertTicket")]
        [ResponseType(typeof(Ticket))]
            public IHttpActionResult PostTicket(Ticket ticket)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Tickets.Add(ticket);
                db.Complete();

                return CreatedAtRoute("DefaultApi", new { id = ticket.Id }, ticket);
            }

        [HttpDelete]
        [Route("DeleteTicket")]
        // DELETE: api/Tickets/5
        [ResponseType(typeof(Ticket))]
            public IHttpActionResult DeleteTicket(int id)
            {
                Ticket ticket = db.Tickets.Get(id);
                if (ticket == null)
                {
                    return NotFound();
                }

                db.Tickets.Remove(ticket);
                db.Complete();

                return Ok(ticket);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

            private bool TicketExists(int id)
            {
                return db.Tickets.GetAll().Count(e => e.Id == id) > 0;
            }
        }
}
