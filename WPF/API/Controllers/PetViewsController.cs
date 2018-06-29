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
    public class PetViewsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/PetViews
        public IQueryable<PetView> GetPetViews()
        {
            return db.PetViews;
        }

        // GET: api/PetViews/5
        [ResponseType(typeof(PetView))]
        public async Task<IHttpActionResult> GetPetView(int id)
        {
            PetView petView = await db.PetViews.FindAsync(id);
            if (petView == null)
            {
                return NotFound();
            }

            return Ok(petView);
        }

        // PUT: api/PetViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPetView(int id, PetView petView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petView.PetID)
            {
                return BadRequest();
            }

            db.Entry(petView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetViewExists(id))
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

        // POST: api/PetViews
        [ResponseType(typeof(PetView))]
        public async Task<IHttpActionResult> PostPetView(PetView petView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetViews.Add(petView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PetViewExists(petView.PetID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = petView.PetID }, petView);
        }

        // DELETE: api/PetViews/5
        [ResponseType(typeof(PetView))]
        public async Task<IHttpActionResult> DeletePetView(int id)
        {
            PetView petView = await db.PetViews.FindAsync(id);
            if (petView == null)
            {
                return NotFound();
            }

            db.PetViews.Remove(petView);
            await db.SaveChangesAsync();

            return Ok(petView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetViewExists(int id)
        {
            return db.PetViews.Count(e => e.PetID == id) > 0;
        }
    }
}