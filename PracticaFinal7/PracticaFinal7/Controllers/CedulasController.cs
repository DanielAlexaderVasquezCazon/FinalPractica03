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
using PracticaFinal7.Models;

namespace PracticaFinal7.Controllers
{
    public class CedulasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Cedulas
        public IQueryable<Cedula> GetCedulas()
        {
            return db.Cedulas;
        }

        // GET: api/Cedulas/5
        [ResponseType(typeof(Cedula))]
        public IHttpActionResult GetCedula(string id)
        {
            Cedula cedula = db.Cedulas.Find(id);
            if (cedula == null)
            {
                return NotFound();
            }

            return Ok(cedula);
        }

        // PUT: api/Cedulas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCedula(string id, Cedula cedula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cedula.nombre)
            {
                return BadRequest();
            }

            db.Entry(cedula).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CedulaExists(id))
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

        // POST: api/Cedulas
        [ResponseType(typeof(Cedula))]
        public IHttpActionResult PostCedula(Cedula cedula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cedulas.Add(cedula);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CedulaExists(cedula.nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cedula.nombre }, cedula);
        }

        // DELETE: api/Cedulas/5
        [ResponseType(typeof(Cedula))]
        public IHttpActionResult DeleteCedula(string id)
        {
            Cedula cedula = db.Cedulas.Find(id);
            if (cedula == null)
            {
                return NotFound();
            }

            db.Cedulas.Remove(cedula);
            db.SaveChanges();

            return Ok(cedula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CedulaExists(string id)
        {
            return db.Cedulas.Count(e => e.nombre == id) > 0;
        }
    }
}