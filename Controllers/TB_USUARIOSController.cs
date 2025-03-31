using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VOTO_SALESIANO.Models;

namespace VOTO_SALESIANO.Controllers
{
    public class TB_USUARIOSController : Controller
    {
        private DB_VOTACIONEntities db = new DB_VOTACIONEntities();

        // GET: TB_USUARIOS
        public ActionResult Index()
        {
            return View(db.TB_USUARIOS.ToList());
        }

        // GET: TB_USUARIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIOS tB_USUARIOS = db.TB_USUARIOS.Find(id);
            if (tB_USUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIOS);
        }

        // GET: TB_USUARIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_USUARIOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESCRIPCION,GRADO")] TB_USUARIOS tB_USUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.TB_USUARIOS.Add(tB_USUARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_USUARIOS);
        }

        // GET: TB_USUARIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIOS tB_USUARIOS = db.TB_USUARIOS.Find(id);
            if (tB_USUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIOS);
        }

        // POST: TB_USUARIOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESCRIPCION,GRADO")] TB_USUARIOS tB_USUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_USUARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_USUARIOS);
        }

        // GET: TB_USUARIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIOS tB_USUARIOS = db.TB_USUARIOS.Find(id);
            if (tB_USUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIOS);
        }

        // POST: TB_USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_USUARIOS tB_USUARIOS = db.TB_USUARIOS.Find(id);
            db.TB_USUARIOS.Remove(tB_USUARIOS);
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
