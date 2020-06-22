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
    public class tbl_LibroController : Controller
    {
        private dbBibliotecaEntities db = new dbBibliotecaEntities();

        // GET: tbl_Libro
        public ActionResult Index()
        {
            var tbl_Libro = db.tbl_Libro.Include(t => t.tblCategoria);
            return View(tbl_Libro.ToList());
        }

        // GET: tbl_Libro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Libro tbl_Libro = db.tbl_Libro.Find(id);
            if (tbl_Libro == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Libro);
        }

        // GET: tbl_Libro/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre");
            return View();
        }

        // POST: tbl_Libro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLibro,Titulo,Autor,ISBN,Fecha_publicacion,Numero_de_Ejemplares,idCategoria")] tbl_Libro tbl_Libro)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Libro.Add(tbl_Libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre", tbl_Libro.idCategoria);
            return View(tbl_Libro);
        }

        // GET: tbl_Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Libro tbl_Libro = db.tbl_Libro.Find(id);
            if (tbl_Libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre", tbl_Libro.idCategoria);
            return View(tbl_Libro);
        }

        // POST: tbl_Libro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLibro,Titulo,Autor,ISBN,Fecha_publicacion,Numero_de_Ejemplares,idCategoria")] tbl_Libro tbl_Libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.tblCategoria, "idCategoria", "nombre", tbl_Libro.idCategoria);
            return View(tbl_Libro);
        }

        // GET: tbl_Libro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Libro tbl_Libro = db.tbl_Libro.Find(id);
            if (tbl_Libro == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Libro);
        }

        // POST: tbl_Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Libro tbl_Libro = db.tbl_Libro.Find(id);
            db.tbl_Libro.Remove(tbl_Libro);
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
