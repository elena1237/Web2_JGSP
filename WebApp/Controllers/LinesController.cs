using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Persistence.Repository;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Line")]
    public class LinesController : ApiController
    {
        private IUnitOfWork db;

        public LinesController(IUnitOfWork db)
        {
            this.db = db;
        }


        [Route("GetScheduleLines")]
        public IEnumerable<Line> GetScheduleLines(string typeOfLine)
        {
            List<Line> lines = new List<Line>();
            var linijice = db.Lines.GetAll().ToList();

            if (typeOfLine == null)
            {


                var type = db.Schedules.GetAll().FirstOrDefault(u => u.ScheduleTypeId == 1);
                return db.Lines.GetAll().Where(u => u.Id == type.LineId);

            }
            else if (typeOfLine == "Prigradski")
            {

                var type = db.Schedules.GetAll().FirstOrDefault(u => u.ScheduleTypeId == 2);
                return db.Lines.GetAll().Where(u => u.Id == type.LineId);

            } else
            {
                var type = db.Schedules.GetAll().FirstOrDefault(u => u.ScheduleTypeId == 1);
                return db.Lines.GetAll().Where(u => u.TypeOfLine == type.ScheduleTypeId);

               
                
            }
        }

        [Route("GetSchedule")]
        public string GetSchedule(string typeOfLine, string typeOfDay, string Number)
        {
            //var type = db.Schedules.GetAll().FirstOrDefault(u => u.ScheduleType.Name == typeOfLine);
            //var day = db.Schedules.GetAll().FirstOrDefault(u => u.DayInWeek.ToString() == typeOfDay);
            var line = db.Lines.GetAll().FirstOrDefault(u => u.LineNumber.ToString() == Number);


            var schedules = db.Schedules.GetAll().ToList();
            var lines = db.Lines.GetAll().ToList();
            var scheduletipes = db.ScheduleTypes.GetAll().Where(e=>e.Name==typeOfLine);


            string dep = "";
            foreach (Schedule l in schedules)
            {
                foreach( var item in scheduletipes)
                { 
                    if ((l.Line.Id == line.Id) && (l.DayInWeek == typeOfDay) && (l.ScheduleTypeId == item.Id))
                    {
                        dep += l.Departure+",";

                    }
                }

            }
            if (dep.Length > 0)
                dep = dep.Substring(0, dep.Length - 1);
            return dep;
          
        }

        //[Route("GetScheduleAdmin")]
        //public IEnumerable<ScheduleLine> GetScheduleAdmin()
        //{
        //    List<ScheduleLine> schedule = new List<ScheduleLine>();
        //    var lines = db.Lines.GetAll();

        //    foreach(var line in lines)
        //    {
        //        ScheduleLine sl = new ScheduleLine();
        //        sl.Number = line.Number;
        //        foreach(var dep in line.Departures)
        //        {
        //            var day = db.Days.GetAll().FirstOrDefault(u => u.IDDay == dep.IDDay);

        //            sl.Time = dep.Time;
        //            sl.Day = day.KindOfDay;
        //            schedule.Add(sl);
        //        }

        //    }

        //    return schedule;

        //}






        // GET: api/Lines
        [Route("AllLines")]
        
        public IEnumerable<Line> GetLines()
        {
            return db.Lines.GetAll();
        }

        // GET: api/Lines/5
        [ResponseType(typeof(Line))]
        public IHttpActionResult GetLine(int id)
        {
            Line line = db.Lines.Get(id);
            if (line == null)
            {
                return NotFound();
            }

            return Ok(line);
        }

        // PUT: api/Lines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLine(int id, Line line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != line.Id)
            {
                return BadRequest();
            }

            db.Lines.Update(line);

            try
            {
                db.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineExists(id))
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

        // POST: api/Lines
        [ResponseType(typeof(Line))]
        [Route("InsertLine")]
        public IHttpActionResult PostLine([FromBody]Line line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lines.Add(line);
            db.Complete();

            return CreatedAtRoute("DefaultApi", new { controller = "line", id = line.Id }, line);
            
        }

        // DELETE: api/Lines/5
        [ResponseType(typeof(Line))]
        public IHttpActionResult DeleteLine(int id)
        {
            Line line = db.Lines.Get(id);
            if (line == null)
            {
                return NotFound();
            }

            db.Lines.Remove(line);
            db.Complete();

            return Ok(line);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineExists(int id)
        {
            return db.Lines.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}