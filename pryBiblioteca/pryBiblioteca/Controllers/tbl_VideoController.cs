using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUBiblioteca;

namespace pryBiblioteca.Controllers
{
    public class tbl_VideoController : Controller
    {
        private dbBibliotecaEntities db = new dbBibliotecaEntities();

        // GET: tbl_Video
        public ActionResult Index()
        {
            var tbl_Video = db.tbl_Video.Include(t => t.tblCategoria);
            return View(tbl_Video.ToList());
        }

        // GET: tbl_Video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Video tbl_Video = db.tbl_Video.Find(id);
            if (tbl_Video == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Video);
        }

        // GET: tbl_Video/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre");
            return View();
        }

        // POST: tbl_Video/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVideo,titulo,fecha_publicacion,duracion_minutos,idCategoria")] tbl_Video tbl_Video)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Video.Add(tbl_Video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre", tbl_Video.idCategoria);
            return View(tbl_Video);
        }

        // GET: tbl_Video/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Video tbl_Video = db.tbl_Video.Find(id);
            if (tbl_Video == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre", tbl_Video.idCategoria);
            return View(tbl_Video);
        }

        // POST: tbl_Video/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVideo,titulo,fecha_publicacion,duracion_minutos,idCategoria")] tbl_Video tbl_Video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre", tbl_Video.idCategoria);
            return View(tbl_Video);
        }

        // GET: tbl_Video/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Video tbl_Video = db.tbl_Video.Find(id);
            if (tbl_Video == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Video);
        }

        // POST: tbl_Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Video tbl_Video = db.tbl_Video.Find(id);
            db.tbl_Video.Remove(tbl_Video);
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
