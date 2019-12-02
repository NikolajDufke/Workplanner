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
using WorkPlannerWebApi;

namespace WorkPlannerWebApi.Controllers
{
    public class AccessesController : ApiController
    {
        private WorkPlannerDBContext db = new WorkPlannerDBContext();

        // GET: api/Accesses
        public IQueryable<Access> GetAccesses()
        {
            return db.Accesses;
        }

        // GET: api/Accesses/5
        [ResponseType(typeof(Access))]
        public IHttpActionResult GetAccess(int id)
        {
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return NotFound();
            }

            return Ok(access);
        }

        // PUT: api/Accesses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccess(int id, Access access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != access.AccessLevel)
            {
                return BadRequest();
            }

            db.Entry(access).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessExists(id))
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

        // POST: api/Accesses
        [ResponseType(typeof(Access))]
        public IHttpActionResult PostAccess(Access access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accesses.Add(access);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccessExists(access.AccessLevel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = access.AccessLevel }, access);
        }

        // DELETE: api/Accesses/5
        [ResponseType(typeof(Access))]
        public IHttpActionResult DeleteAccess(int id)
        {
            Access access = db.Accesses.Find(id);
            if (access == null)
            {
                return NotFound();
            }

            db.Accesses.Remove(access);
            db.SaveChanges();

            return Ok(access);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccessExists(int id)
        {
            return db.Accesses.Count(e => e.AccessLevel == id) > 0;
        }
    }
}