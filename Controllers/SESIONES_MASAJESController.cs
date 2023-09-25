using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MASAJES.Models;

namespace MASAJES.Controllers
{
    public class SESIONES_MASAJESController : Controller
    {
        private DB_MASAJESEntities db = new DB_MASAJESEntities();

        // GET: SESIONES_MASAJES
        public ActionResult Index()
        {
            return View(db.SESIONES_MASAJES.ToList());
        }

        // GET: SESIONES_MASAJES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESIONES_MASAJES sESIONES_MASAJES = db.SESIONES_MASAJES.Find(id);
            if (sESIONES_MASAJES == null)
            {
                return HttpNotFound();
            }
            return View(sESIONES_MASAJES);
        }

        // GET: SESIONES_MASAJES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SESIONES_MASAJES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,TELEFONO,FECHA,HORA,PRECIO,DESCRIPCION")] SESIONES_MASAJES sESIONES_MASAJES)
        {
            if (ModelState.IsValid)
            {
                db.SESIONES_MASAJES.Add(sESIONES_MASAJES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sESIONES_MASAJES);
        }

        // GET: SESIONES_MASAJES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESIONES_MASAJES sESIONES_MASAJES = db.SESIONES_MASAJES.Find(id);
            if (sESIONES_MASAJES == null)
            {
                return HttpNotFound();
            }
            return View(sESIONES_MASAJES);
        }

        // POST: SESIONES_MASAJES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,TELEFONO,FECHA,HORA,PRECIO,DESCRIPCION")] SESIONES_MASAJES sESIONES_MASAJES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sESIONES_MASAJES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sESIONES_MASAJES);
        }

        // GET: SESIONES_MASAJES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESIONES_MASAJES sESIONES_MASAJES = db.SESIONES_MASAJES.Find(id);
            if (sESIONES_MASAJES == null)
            {
                return HttpNotFound();
            }
            return View(sESIONES_MASAJES);
        }

        // POST: SESIONES_MASAJES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SESIONES_MASAJES sESIONES_MASAJES = db.SESIONES_MASAJES.Find(id);
            db.SESIONES_MASAJES.Remove(sESIONES_MASAJES);
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
