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
    public class PriceListsController : ApiController
    {
        private WebAppContext db = new WebAppContext();

        // GET: api/PriceLists
        public IQueryable<PriceList> GetPriceLists()
        {
            return db.PriceLists;
        }

        // GET: api/PriceLists/5
        [ResponseType(typeof(PriceList))]
        public IHttpActionResult GetPriceList(int id)
        {
            PriceList priceList = db.PriceLists.Find(id);
            if (priceList == null)
            {
                return NotFound();
            }

            return Ok(priceList);
        }

        // PUT: api/PriceLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPriceList(int id, PriceList priceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceList.Id)
            {
                return BadRequest();
            }

            db.Entry(priceList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceListExists(id))
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

        // POST: api/PriceLists
        [ResponseType(typeof(PriceList))]
        public IHttpActionResult PostPriceList(PriceList priceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceLists.Add(priceList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = priceList.Id }, priceList);
        }

        // DELETE: api/PriceLists/5
        [ResponseType(typeof(PriceList))]
        public IHttpActionResult DeletePriceList(int id)
        {
            PriceList priceList = db.PriceLists.Find(id);
            if (priceList == null)
            {
                return NotFound();
            }

            db.PriceLists.Remove(priceList);
            db.SaveChanges();

            return Ok(priceList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriceListExists(int id)
        {
            return db.PriceLists.Count(e => e.Id == id) > 0;
        }
    }
}