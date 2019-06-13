using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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
        
        [Route("InsertTimeTicket")]
        [ResponseType(typeof(bool))]
        [AllowAnonymous]
        public IHttpActionResult PostTimeTicket(Email email)
        {
            
            TicketType timeTicket = db.TicketTypes.Find(x => x.Name == "Vremenska").FirstOrDefault();
            
            //ticket.TicketType.Id = timeTicket.Id;
            Ticket ticket = new Ticket(timeTicket,null,true, (DateTime.Now).ToString());

            db.Tickets.Add(ticket);
            db.Complete();

            DateTime validTo = DateTime.Now.AddHours(1);

            try
            {
                SendEmail(email.Value, "GSP Service, kupovina karte.", $"Postovani, Vasa karta traje sat vremena i istice {validTo}.\n  Hvala na koriscenju usluga");

                return Ok(true);

            }
            catch (Exception)
            {
                return Ok(false);
            }


        }




        private void SendEmail(string recipient, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            try
            {
                mail.To.Add(recipient);
            }
            catch (Exception e) { }

            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress("titovrentavehicle@gmail.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("titovrentavehicle@gmail.com", "drugtito");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
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
