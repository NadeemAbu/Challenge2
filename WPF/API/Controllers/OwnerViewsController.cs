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
    public class OwnerViewsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/OwnerViews
        public IQueryable<OwnerView> GetOwnerViews()
        {
            return db.OwnerViews;
        }

        // GET: api/OwnerViews/5
        [ResponseType(typeof(OwnerView))]
        public async Task<IHttpActionResult> GetOwnerView(int id)
        {
            OwnerView ownerView = await db.OwnerViews.FindAsync(id);
            if (ownerView == null)
            {
                return NotFound();
            }

            return Ok(ownerView);
        }

        // PUT: api/OwnerViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOwnerView(int id, OwnerView ownerView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ownerView.OwnerID)
            {
                return BadRequest();
            }

            db.Entry(ownerView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerViewExists(id))
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

        // POST: api/OwnerViews
        [ResponseType(typeof(OwnerView))]
        public async Task<IHttpActionResult> PostOwnerView(OwnerView ownerView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OwnerViews.Add(ownerView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OwnerViewExists(ownerView.OwnerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ownerView.OwnerID }, ownerView);
        }

        // DELETE: api/OwnerViews/5
        [ResponseType(typeof(OwnerView))]
        public async Task<IHttpActionResult> DeleteOwnerView(int id)
        {
            OwnerView ownerView = await db.OwnerViews.FindAsync(id);
            if (ownerView == null)
            {
                return NotFound();
            }

            db.OwnerViews.Remove(ownerView);
            await db.SaveChangesAsync();

            return Ok(ownerView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OwnerViewExists(int id)
        {
            return db.OwnerViews.Count(e => e.OwnerID == id) > 0;
        }
    }
}