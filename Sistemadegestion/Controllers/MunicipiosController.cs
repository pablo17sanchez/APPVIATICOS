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
    public class MunicipiosController : Controller
    {
        private DB db = new DB();

        
        public ActionResult Index()
        {
            return View(db.Municipios.ToList());
        }

        [Autenticado]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

       [Autenticado]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult Create([Bind(Include = "id,COD_REGION,COD_PROVINCIA,COD_MUNICIPIO,NOM_MUNICIPIO")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipios.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(municipio);
        }

           [Autenticado]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult Edit([Bind(Include = "id,COD_REGION,COD_PROVINCIA,COD_MUNICIPIO,NOM_MUNICIPIO")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(municipio);
        }

             [Autenticado]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            db.Municipios.Remove(municipio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*

        public JsonResult IsMunicipioExist(string Codigomunicipio)
        {
            var validateName = db.Municipios.FirstOrDefault
                                (x => x.COD_MUNICIPIO == Codigomunicipio);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }*/
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
