using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using proyecto.Areas.Admin.Filters;

namespace Sistemadegestion.Controllers
{
    public class ObjetalsController : Controller
    {
        private DB db = new DB();


        public ActionResult Index()
        {
            return View(db.Objetals.ToList());
        }

        [Autenticado]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetal objetal = db.Objetals.Find(id);
            if (objetal == null)
            {
                return HttpNotFound();
            }
            return View(objetal);
        }

        [Autenticado]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objetals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult Create([Bind(Include = "id,codigo_objetal,nombre_objetal")] Objetal objetal)
        {
            if (ModelState.IsValid)
            {
                db.Objetals.Add(objetal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objetal);
        }

        [Autenticado]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetal objetal = db.Objetals.Find(id);
            if (objetal == null)
            {
                return HttpNotFound();
            }
            return View(objetal);
        }

        // POST: Objetals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult Edit([Bind(Include = "id,codigo_objetal,nombre_objetal")] Objetal objetal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objetal);
        }

        [Autenticado]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetal objetal = db.Objetals.Find(id);
            if (objetal == null)
            {
                return HttpNotFound();
            }
            return View(objetal);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult DeleteConfirmed(int id)
        {
            Objetal objetal = db.Objetals.Find(id);
            db.Objetals.Remove(objetal);
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
