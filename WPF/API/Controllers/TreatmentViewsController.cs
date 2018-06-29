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
    public class TreatmentViewsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/TreatmentViews
        public IQueryable<TreatmentView> GetTreatmentViews()
        {
            return db.TreatmentViews;
        }

        // GET: api/TreatmentViews/5
        [ResponseType(typeof(TreatmentView))]
        public async Task<IHttpActionResult> GetTreatmentView(int id)
        {
            TreatmentView treatmentView = await db.TreatmentViews.FindAsync(id);
            if (treatmentView == null)
            {
                return NotFound();
            }

            return Ok(treatmentView);
        }

        // PUT: api/TreatmentViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTreatmentView(int id, TreatmentView treatmentView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatmentView.TreatmentID)
            {
                return BadRequest();
            }

            db.Entry(treatmentView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentViewExists(id))
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

        // POST: api/TreatmentViews
        [ResponseType(typeof(TreatmentView))]
        public async Task<IHttpActionResult> PostTreatmentView(TreatmentView treatmentView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TreatmentViews.Add(treatmentView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TreatmentViewExists(treatmentView.TreatmentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = treatmentView.TreatmentID }, treatmentView);
        }

        // DELETE: api/TreatmentViews/5
        [ResponseType(typeof(TreatmentView))]
        public async Task<IHttpActionResult> DeleteTreatmentView(int id)
        {
            TreatmentView treatmentView = await db.TreatmentViews.FindAsync(id);
            if (treatmentView == null)
            {
                return NotFound();
            }

            db.TreatmentViews.Remove(treatmentView);
            await db.SaveChangesAsync();

            return Ok(treatmentView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreatmentViewExists(int id)
        {
            return db.TreatmentViews.Count(e => e.TreatmentID == id) > 0;
        }
    }
}