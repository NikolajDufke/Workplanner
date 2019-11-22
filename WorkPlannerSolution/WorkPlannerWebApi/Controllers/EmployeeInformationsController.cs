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
    public class EmployeeInformationsController : ApiController
    {
        private WorkPlannerDBContext db = new WorkPlannerDBContext();

        // GET: api/EmployeeInformations
        public IQueryable<EmployeeInformation> GetEmployeeInformations()
        {
            return db.EmployeeInformations;
        }

        // GET: api/EmployeeInformations/5
        [ResponseType(typeof(EmployeeInformation))]
        public IHttpActionResult GetEmployeeInformation(int id)
        {
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return NotFound();
            }

            return Ok(employeeInformation);
        }

        // PUT: api/EmployeeInformations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeInformation(int id, EmployeeInformation employeeInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeInformation.EInformationID)
            {
                return BadRequest();
            }

            db.Entry(employeeInformation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInformationExists(id))
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

        // POST: api/EmployeeInformations
        [ResponseType(typeof(EmployeeInformation))]
        public IHttpActionResult PostEmployeeInformation(EmployeeInformation employeeInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeInformations.Add(employeeInformation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeInformation.EInformationID }, employeeInformation);
        }

        // DELETE: api/EmployeeInformations/5
        [ResponseType(typeof(EmployeeInformation))]
        public IHttpActionResult DeleteEmployeeInformation(int id)
        {
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return NotFound();
            }

            db.EmployeeInformations.Remove(employeeInformation);
            db.SaveChanges();

            return Ok(employeeInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeInformationExists(int id)
        {
            return db.EmployeeInformations.Count(e => e.EInformationID == id) > 0;
        }
    }
}