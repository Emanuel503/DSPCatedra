using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using veterinaria.Models;

namespace veterinaria.Controllers
{
    public class consultaMedicaController : Controller
    {
        private veterinariaEntities db = new veterinariaEntities();

        // GET: consultaMedica
        public ActionResult Index()
        {
            var consultaMedica = db.consultaMedica.Include(c => c.mascota).Include(c => c.personal);
            return View(consultaMedica.ToList());
        }

        // GET: consultaMedica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultaMedica consultaMedica = db.consultaMedica.Find(id);
            if (consultaMedica == null)
            {
                return HttpNotFound();
            }
            return View(consultaMedica);
        }

        // GET: consultaMedica/Create
        public ActionResult Create()
        {
            ViewBag.idMascota = new SelectList(db.mascota, "idMascota", "nombreMascota");
            ViewBag.idPersonal = new SelectList(db.personal, "idPersonal", "nombre");
            return View();
        }

        // POST: consultaMedica/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCita,idMascota,idPersonal,descripcionConsulta,fechaConsulta,costoConsulta")] consultaMedica consultaMedica)
        {
            if (ModelState.IsValid)
            {
                db.consultaMedica.Add(consultaMedica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMascota = new SelectList(db.mascota, "idMascota", "nombreMascota", consultaMedica.idMascota);
            ViewBag.idPersonal = new SelectList(db.personal, "idPersonal", "nombre", consultaMedica.idPersonal);
            return View(consultaMedica);
        }

        // GET: consultaMedica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultaMedica consultaMedica = db.consultaMedica.Find(id);
            if (consultaMedica == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMascota = new SelectList(db.mascota, "idMascota", "nombreMascota", consultaMedica.idMascota);
            ViewBag.idPersonal = new SelectList(db.personal, "idPersonal", "nombre", consultaMedica.idPersonal);
            return View(consultaMedica);
        }

        // POST: consultaMedica/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCita,idMascota,idPersonal,descripcionConsulta,fechaConsulta,costoConsulta")] consultaMedica consultaMedica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultaMedica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMascota = new SelectList(db.mascota, "idMascota", "nombreMascota", consultaMedica.idMascota);
            ViewBag.idPersonal = new SelectList(db.personal, "idPersonal", "nombre", consultaMedica.idPersonal);
            return View(consultaMedica);
        }

        // GET: consultaMedica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultaMedica consultaMedica = db.consultaMedica.Find(id);
            if (consultaMedica == null)
            {
                return HttpNotFound();
            }
            return View(consultaMedica);
        }

        // POST: consultaMedica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consultaMedica consultaMedica = db.consultaMedica.Find(id);
            db.consultaMedica.Remove(consultaMedica);
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
