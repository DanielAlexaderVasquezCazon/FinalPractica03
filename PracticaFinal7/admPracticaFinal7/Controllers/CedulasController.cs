using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admPracticaFinal7.Models;

namespace admPracticaFinal7.Controllers
{
    public class CedulasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cedulas
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Cedulas.ToList());
        }

        // GET: Cedulas/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cedula cedula = db.Cedulas.Find(id);
            if (cedula == null)
            {
                return HttpNotFound();
            }
            return View(cedula);
        }

        // GET: Cedulas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cedulas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,apellido")] Cedula cedula)
        {
            if (ModelState.IsValid)
            {
                db.Cedulas.Add(cedula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cedula);
        }

        // GET: Cedulas/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cedula cedula = db.Cedulas.Find(id);
            if (cedula == null)
            {
                return HttpNotFound();
            }
            return View(cedula);
        }

        // POST: Cedulas/Edit/5
       
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,apellido")] Cedula cedula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cedula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cedula);
        }

        // GET: Cedulas/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cedula cedula = db.Cedulas.Find(id);
            if (cedula == null)
            {
                return HttpNotFound();
            }
            return View(cedula);
        }

        // POST: Cedulas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cedula cedula = db.Cedulas.Find(id);
            db.Cedulas.Remove(cedula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
