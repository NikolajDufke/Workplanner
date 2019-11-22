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
using WorkPlannerWebAPI;

namespace WorkPlannerWebAPI.Controllers
{
    public class WorktimesController : ApiController
    {
        private WorkPlannerDBContext db = new WorkPlannerDBContext();

        // GET: api/Worktimes
        public IQueryable<Worktime> GetWorktimes()
        {
            return db.Worktimes;
        }

        // GET: api/Worktimes/5
        [ResponseType(typeof(Worktime))]
        public IHttpActionResult GetWorktime(int id)
        {
            Worktime worktime = db.Worktimes.Find(id);
            if (worktime == null)
            {
                return NotFound();
            }

            return Ok(worktime);
        }

        // PUT: api/Worktimes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorktime(int id, Worktime worktime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worktime.WorkTimeID)
            {
                return BadRequest();
            }

            db.Entry(worktime).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorktimeExists(id))
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

        // POST: api/Worktimes
        [ResponseType(typeof(Worktime))]
        public IHttpActionResult PostWorktime(Worktime worktime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Worktimes.Add(worktime);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WorktimeExists(worktime.WorkTimeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = worktime.WorkTimeID }, worktime);
        }

        // DELETE: api/Worktimes/5
        [ResponseType(typeof(Worktime))]
        public IHttpActionResult DeleteWorktime(int id)
        {
            Worktime worktime = db.Worktimes.Find(id);
            if (worktime == null)
            {
                return NotFound();
            }

            db.Worktimes.Remove(worktime);
            db.SaveChanges();

            return Ok(worktime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorktimeExists(int id)
        {
            return db.Worktimes.Count(e => e.WorkTimeID == id) > 0;
        }
    }
}