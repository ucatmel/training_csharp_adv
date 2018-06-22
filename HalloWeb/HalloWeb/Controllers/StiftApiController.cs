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
using HalloWeb.Models;

namespace HalloWeb.Controllers
{
    public class StiftApiController : ApiController
    {
        private HalloWebContext db = new HalloWebContext();

        // GET: api/StiftApi
        public IQueryable<Stift> GetStifts()
        {
            return db.Stifts;
        }

        // GET: api/StiftApi/5
        [ResponseType(typeof(Stift))]
        public IHttpActionResult GetStift(int id)
        {
            Stift stift = db.Stifts.Find(id);
            if (stift == null)
            {
                return NotFound();
            }

            return Ok(stift);
        }

        // PUT: api/StiftApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStift(int id, Stift stift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stift.id)
            {
                return BadRequest();
            }

            db.Entry(stift).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StiftExists(id))
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

        // POST: api/StiftApi
        [ResponseType(typeof(Stift))]
        public IHttpActionResult PostStift(Stift stift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stifts.Add(stift);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stift.id }, stift);
        }

        // DELETE: api/StiftApi/5
        [ResponseType(typeof(Stift))]
        public IHttpActionResult DeleteStift(int id)
        {
            Stift stift = db.Stifts.Find(id);
            if (stift == null)
            {
                return NotFound();
            }

            db.Stifts.Remove(stift);
            db.SaveChanges();

            return Ok(stift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StiftExists(int id)
        {
            return db.Stifts.Count(e => e.id == id) > 0;
        }
    }
}