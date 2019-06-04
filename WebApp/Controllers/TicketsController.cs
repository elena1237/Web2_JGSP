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
        public IEnumerable<BaseTicket> GetTickets()
            {
                return db.Tickets.GetAll();
            }
        
        [HttpGet]
        [Route("GetById")]
            // GET: api/Tickets/5
            [ResponseType(typeof(BaseTicket))]
            public IHttpActionResult GetTicket(int id)
            {
                BaseTicket ticket = db.Tickets.Get(id);
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
            public IHttpActionResult PutTicket(int id, BaseTicket ticket)
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
        [ResponseType(typeof(BaseTicket))]
            public IHttpActionResult PostTicket(BaseTicket ticket)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Tickets.Add(ticket);
                db.Complete();

                return CreatedAtRoute("DefaultApi", new { id = ticket.Id }, ticket);
            }


        // POST: api/Tickets
        [HttpPost]
        [Route("InsertTimeTicket")]
        [ResponseType(typeof(BaseTicket))]
        public IHttpActionResult PostTimeTicket()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //PassengerType pt = new PassengerType();
            //Passenger pass = new Passenger("UserFirst", "UserLast", "Address", "Role", "10.05.1994.", false,pt,"img","UserName",false,"user@gmail.com");
            //TicketType tt = new TicketType();
            BaseTicket timeticket = new BaseTicket();
            timeticket.IsValid = true;
            timeticket.TimeIssued = (DateTime.Now).ToString();


            db.Tickets.Add(timeticket);
            db.Complete();

            return CreatedAtRoute("DefaultApi", new { id = timeticket.Id }, timeticket);
        }

        [HttpDelete]
        [Route("DeleteTicket")]
        // DELETE: api/Tickets/5
        [ResponseType(typeof(BaseTicket))]
            public IHttpActionResult DeleteTicket(int id)
            {
                BaseTicket ticket = db.Tickets.Get(id);
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
