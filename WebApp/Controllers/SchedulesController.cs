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
using System.Web.UI;
using WebApp.Models;
using WebApp.Persistence.Repository;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    [RoutePrefix("Api/Schedules")]
    public class SchedulesController : ApiController
    {

        public IUnitOfWork _unitOfWork { get; set; }

        public SchedulesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //[Authorize(Roles = "Admin")]
        [Route("AdminSchedules")]
        // GET: api/Schedules
        public IEnumerable<Schedule> GetSchedules()
        {
            return _unitOfWork.Schedules.GetAll();

        }

        // GET: api/Schedules/5
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult GetSchedule(int id)
        {
            Schedule schedule = _unitOfWork.Schedules.Get(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        // PUT: api/Schedules/5
        [ResponseType(typeof(void))]
        [Route("PutSchedule")]

        public IHttpActionResult PutSchedule(int id, Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schedule.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Schedules.Update(schedule);

            try
            {
                _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedules
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult PostSchedule(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Schedules.Add(schedule);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = schedule.Id }, schedule);
        }

        // DELETE: api/Schedules/5
        [ResponseType(typeof(Schedule))]
        
        [Route("DeleteSchedule")]
        public IHttpActionResult DeleteSchedule(int id)
        {
            Schedule schedule = _unitOfWork.Schedules.Get(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _unitOfWork.Schedules.Remove(schedule);
            _unitOfWork.Complete();
            


            return Ok(schedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScheduleExists(int id)
        {
            return _unitOfWork.Schedules.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}