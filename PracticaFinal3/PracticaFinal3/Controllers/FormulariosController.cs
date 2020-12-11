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
using PracticaFinal3.Models;

namespace PracticaFinal3.Controllers
{
    public class FormulariosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Formularios
        public IQueryable<Formulario> GetFormularios()
        {
            return db.Formularios;
        }

        // GET: api/Formularios/5
        [ResponseType(typeof(Formulario))]
        public IHttpActionResult GetFormulario(int id)
        {
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return NotFound();
            }

            return Ok(formulario);
        }

        // PUT: api/Formularios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormulario(int id, Formulario formulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formulario.vasquezID)
            {
                return BadRequest();
            }

            db.Entry(formulario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormularioExists(id))
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

        // POST: api/Formularios
        [ResponseType(typeof(Formulario))]
        public IHttpActionResult PostFormulario(Formulario formulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Formularios.Add(formulario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = formulario.vasquezID }, formulario);
        }

        // DELETE: api/Formularios/5
        [ResponseType(typeof(Formulario))]
        public IHttpActionResult DeleteFormulario(int id)
        {
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return NotFound();
            }

            db.Formularios.Remove(formulario);
            db.SaveChanges();

            return Ok(formulario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormularioExists(int id)
        {
            return db.Formularios.Count(e => e.vasquezID == id) > 0;
        }
    }
}