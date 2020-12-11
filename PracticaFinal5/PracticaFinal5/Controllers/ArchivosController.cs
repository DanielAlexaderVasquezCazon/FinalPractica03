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
using PracticaFinal5.Models;

namespace PracticaFinal5.Controllers
{
    public class ArchivosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Archivos
        public IQueryable<Archivo> GetArchivoes()
        {
            return db.Archivoes;
        }

        // GET: api/Archivos/5
        [ResponseType(typeof(Archivo))]
        public IHttpActionResult GetArchivo(string id)
        {
            Archivo archivo = db.Archivoes.Find(id);
            if (archivo == null)
            {
                return NotFound();
            }

            return Ok(archivo);
        }

        // PUT: api/Archivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArchivo(string id, Archivo archivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archivo.Nombre)
            {
                return BadRequest();
            }

            db.Entry(archivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivoExists(id))
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

        // POST: api/Archivos
        [ResponseType(typeof(Archivo))]
        public IHttpActionResult PostArchivo(Archivo archivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Archivoes.Add(archivo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ArchivoExists(archivo.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = archivo.Nombre }, archivo);
        }

        // DELETE: api/Archivos/5
        [ResponseType(typeof(Archivo))]
        public IHttpActionResult DeleteArchivo(string id)
        {
            Archivo archivo = db.Archivoes.Find(id);
            if (archivo == null)
            {
                return NotFound();
            }

            db.Archivoes.Remove(archivo);
            db.SaveChanges();

            return Ok(archivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArchivoExists(string id)
        {
            return db.Archivoes.Count(e => e.Nombre == id) > 0;
        }
    }
}