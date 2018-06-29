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
using API.Models;

namespace API.Controllers
{
    public class ProcedureViewsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/ProcedureViews
        public IQueryable<ProcedureView> GetProcedureViews()
        {
            return db.ProcedureViews;
        }

        // GET: api/ProcedureViews/5
        [ResponseType(typeof(ProcedureView))]
        public async Task<IHttpActionResult> GetProcedureView(int id)
        {
            ProcedureView procedureView = await db.ProcedureViews.FindAsync(id);
            if (procedureView == null)
            {
                return NotFound();
            }

            return Ok(procedureView);
        }

        // PUT: api/ProcedureViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProcedureView(int id, ProcedureView procedureView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedureView.ProcedureID)
            {
                return BadRequest();
            }

            db.Entry(procedureView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureViewExists(id))
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

        // POST: api/ProcedureViews
        [ResponseType(typeof(ProcedureView))]
        public async Task<IHttpActionResult> PostProcedureView(ProcedureView procedureView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProcedureViews.Add(procedureView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProcedureViewExists(procedureView.ProcedureID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = procedureView.ProcedureID }, procedureView);
        }

        // DELETE: api/ProcedureViews/5
        [ResponseType(typeof(ProcedureView))]
        public async Task<IHttpActionResult> DeleteProcedureView(int id)
        {
            ProcedureView procedureView = await db.ProcedureViews.FindAsync(id);
            if (procedureView == null)
            {
                return NotFound();
            }

            db.ProcedureViews.Remove(procedureView);
            await db.SaveChangesAsync();

            return Ok(procedureView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcedureViewExists(int id)
        {
            return db.ProcedureViews.Count(e => e.ProcedureID == id) > 0;
        }
    }
}