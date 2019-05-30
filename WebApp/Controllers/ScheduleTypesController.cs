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
    public class ScheduleTypesController : ApiController
    {
        private WebAppContext db = new WebAppContext();

        // GET: api/ScheduleTypes
        public IQueryable<ScheduleType> GetScheduleTypes()
        {
            return db.ScheduleTypes;
        }

        // GET: api/ScheduleTypes/5
        [ResponseType(typeof(ScheduleType))]
        public IHttpActionResult GetScheduleType(int id)
        {
            ScheduleType scheduleType = db.ScheduleTypes.Find(id);
            if (scheduleType == null)
            {
                return NotFound();
            }

            return Ok(scheduleType);
        }

        // PUT: api/ScheduleTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutScheduleType(int id, ScheduleType scheduleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scheduleType.Id)
            {
                return BadRequest();
            }

            db.Entry(scheduleType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleTypeExists(id))
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

        // POST: api/ScheduleTypes
        [ResponseType(typeof(ScheduleType))]
        public IHttpActionResult PostScheduleType(ScheduleType scheduleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ScheduleTypes.Add(scheduleType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = scheduleType.Id }, scheduleType);
        }

        // DELETE: api/ScheduleTypes/5
        [ResponseType(typeof(ScheduleType))]
        public IHttpActionResult DeleteScheduleType(int id)
        {
            ScheduleType scheduleType = db.ScheduleTypes.Find(id);
            if (scheduleType == null)
            {
                return NotFound();
            }

            db.ScheduleTypes.Remove(scheduleType);
            db.SaveChanges();

            return Ok(scheduleType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScheduleTypeExists(int id)
        {
            return db.ScheduleTypes.Count(e => e.Id == id) > 0;
        }
    }
}