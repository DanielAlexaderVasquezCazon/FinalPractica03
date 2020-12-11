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
using PracticaFinal6.Models;

namespace PracticaFinal6.Controllers
{
    public class DatosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Datos
        public IQueryable<Dato> GetDatoes()
        {
            return db.Datoes;
        }

        // GET: api/Datos/5
        [ResponseType(typeof(Dato))]
        public IHttpActionResult GetDato(string id)
        {
            Dato dato = db.Datoes.Find(id);
            if (dato == null)
            {
                return NotFound();
            }

            return Ok(dato);
        }

        // PUT: api/Datos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDato(string id, Dato dato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dato.Nombre)
            {
                return BadRequest();
            }

            db.Entry(dato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoExists(id))
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

        // POST: api/Datos
        [ResponseType(typeof(Dato))]
        public IHttpActionResult PostDato(Dato dato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Datoes.Add(dato);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DatoExists(dato.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dato.Nombre }, dato);
        }

        // DELETE: api/Datos/5
        [ResponseType(typeof(Dato))]
        public IHttpActionResult DeleteDato(string id)
        {
            Dato dato = db.Datoes.Find(id);
            if (dato == null)
            {
                return NotFound();
            }

            db.Datoes.Remove(dato);
            db.SaveChanges();

            return Ok(dato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatoExists(string id)
        {
            return db.Datoes.Count(e => e.Nombre == id) > 0;
        }
    }
}