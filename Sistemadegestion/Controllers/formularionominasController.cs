using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Sistemadegestion.Controllers
{
    public class formularionominasController : Controller
    {
        private DB db = new DB();

     
        public ActionResult Index()
        {
            return View(db.formularionomina.ToList());
        }

     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            formularionomina formularionomina = db.formularionomina.Find(id);
            if (formularionomina == null)
            {
                return HttpNotFound();
            }
            return View(formularionomina);
        }

    
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Identificacion,Tipo_identificacion,Capitulo,Subcapitulo,DAF,UE,Programa,Subprograma,Proyecto,Actividad,Objeto,Fondo,Organismo_Financiador,Tarjeta,codigo_del_banco,tipo_de_cuenta,Nodecuentabancaria,Codigo_de_moneda,FechaActual,Beneficiario,Cargo,Concepto,Cedula,FechaNomina,NombredelDepartamento,Codigodepartamento,Codigocargo,Region,Provincia,Municipio,Funcion,CCP")] formularionomina formularionomina)
        {
            if (ModelState.IsValid)
            {
                db.formularionomina.Add(formularionomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formularionomina);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            formularionomina formularionomina = db.formularionomina.Find(id);
            if (formularionomina == null)
            {
                return HttpNotFound();
            }
            return View(formularionomina);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Identificacion,Tipo_identificacion,Capitulo,Subcapitulo,DAF,UE,Programa,Subprograma,Proyecto,Actividad,Objeto,Fondo,Organismo_Financiador,Tarjeta,codigo_del_banco,tipo_de_cuenta,Nodecuentabancaria,Codigo_de_moneda,FechaActual,Beneficiario,Cargo,Concepto,Cedula,FechaNomina,NombredelDepartamento,Codigodepartamento,Codigocargo,Region,Provincia,Municipio,Funcion,CCP")] formularionomina formularionomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formularionomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formularionomina);
        }

        // GET: formularionominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            formularionomina formularionomina = db.formularionomina.Find(id);
            if (formularionomina == null)
            {
                return HttpNotFound();
            }
            return View(formularionomina);
        }

        // POST: formularionominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            formularionomina formularionomina = db.formularionomina.Find(id);
            db.formularionomina.Remove(formularionomina);
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
