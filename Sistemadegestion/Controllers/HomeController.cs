using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.ViewModel;
using Repository;
using System.IO;
using System.Text;
using System.Net;
using System.Data.Entity;
using proyecto.Areas.Admin.Filters;

using Repository;
namespace Sistemadegestion.Controllers
{
    public class HomeController : Controller
    {
        DB DATABASE = new DB();
        formularioaccessread read = new formularioaccessread();
        private formularionomina sd = new formularionomina();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Autenticado]
        public ActionResult Create()
        {





            formularioviewmodel formulario = new formularioviewmodel();
            //Cargar Dropdwonlist
            formulario.ObjetalList = read.GetObjetales();
            formulario.ActividadList = read.GetActividades();
            formulario.MonedaList = read.GetMoneda();
            //agregadas
            formulario.Regionlist = read.GetRegion();
            formulario.Cuentapresupestales = read.GetCuentaPresupuestales();
            formulario.ProvinciasList = read.GetProvincias();
            formulario.TipodeCuentaList = read.GetTipodeCuenta();

            formulario.MunicipioList = read.GetMunicipios();
            formulario.Funciones = read.GetFunciones();
            return View(formulario);

        }



        [HttpPost]
        // [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult Create(formularioviewmodel formulariosview)
        {



            formulariosview.ObjetalList = read.GetObjetales();

            formulariosview.ActividadList = read.GetActividades();
            formulariosview.TipodeCuentaList = read.GetTipodeCuenta();
            formulariosview.MonedaList = read.GetMoneda();
            formulariosview.Regionlist = read.GetRegion();
            formulariosview.Cuentapresupestales = read.GetCuentaPresupuestales();
            formulariosview.ProvinciasList = read.GetProvincias();


            formulariosview.MunicipioList = read.GetMunicipios();
            formulariosview.Funciones = read.GetFunciones();



            if (ModelState.IsValid)
            {

                DATABASE.formularionomina.Add(formulariosview.formulario);
                DATABASE.SaveChanges();




                return RedirectToAction("List");

            }



            return View(formulariosview);



        }




        [HttpGet]

        public JsonResult Getregistrosformularios(String cedula)
        {

            if (String.IsNullOrEmpty(cedula))
            {



                DateTime fecha = Convert.ToDateTime(DateTime.Now.ToString());


                var resultado = (DATABASE.formularionomina.OrderByDescending(x => x.FechaActual).ToList()).Take(10);



                return Json(
    resultado.Select(x => new
    {
        Montoviaticos = x.MontoViatico,
        Beneficiario = x.Beneficiario,
        Identificacion = x.Identificacion,
        Tipo_identificacion = x.Tipo_identificacion,
        Tarjeta = x.Tarjeta,
        Region = x.Region,
        Provincia = x.Provincia,
        Municipio = x.Municipio,
        FechaNomina = x.FechaNomina,
        id = x.Id

    }), JsonRequestBehavior.AllowGet);





            }
            else
            {
                var results = DATABASE.formularionomina.Where(X => X.Cedula.Contains(cedula))
                      .Select(X => X);

                var resultado = (DATABASE.formularionomina.Where(row => row.Cedula.Contains(cedula)).OrderByDescending(x => x.FechaActual).ToList()).Take(10);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }




        }



        [HttpGet]
        public JsonResult getprovincias(String regionid)
        {


            String resultado = (regionid == null) ? "00000" : regionid;


            string resutado_convertido = Convert.ToString(resultado);

            var resultadodelistado = DATABASE.Provincias.Where(x => x.COD_REGION == resutado_convertido).OrderBy(x => x.COD_PROVINCIA).ToList();


            return Json(
   resultadodelistado.Select(x => new
   {
       Text = x.NOM_PROVINCIA,
       Value = x.COD_PROVINCIA

   }), JsonRequestBehavior.AllowGet);




        }




        [HttpGet]
        public JsonResult Gemunicipios(String provinciaid)
        {


            String resultado = (provinciaid == null) ? "00000" : provinciaid;


            string resutado_convertido = Convert.ToString(resultado);

            var resultadodelistado = DATABASE.Municipios.Where(x => x.COD_PROVINCIA == resutado_convertido).OrderBy(x => x.COD_PROVINCIA).ToList();


            return Json(
   resultadodelistado.Select(x => new
   {
       Text = x.NOM_MUNICIPIO,
       Value = x.COD_MUNICIPIO

   }), JsonRequestBehavior.AllowGet);




        }





        public JsonResult Gerpersonal(string cedula)
        {




            var resultado = DATABASE.Personals.Where(x => x.Cedula == cedula).SingleOrDefault();




            return Json(resultado, JsonRequestBehavior.AllowGet);

        }





        public FileStreamResult CreateFile()
        {

            var string_with_your_data = "";

            var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", "archivodebiaticos.txt");
        }


        [HttpGet]
        [Autenticado]
        public ActionResult List()
        {
            var res = DATABASE.formularionomina.OrderByDescending(x => x.FechaActual).ToList();

            return View(res);
        }







        [Autenticado]
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            }
            formularionomina formulario = DATABASE.formularionomina.Find(id);
            if (formulario == null)
            {
                return HttpNotFound();
            }

            return View(formulario);



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult Edit(formularionomina formularionomina)
        {

            if (ModelState.IsValid)
            {
                DATABASE.Entry(formularionomina).State = EntityState.Modified;
                DATABASE.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(formularionomina);
        }


        [HttpPost]
        public JsonResult Delete(int? id)
        {
            bool result = false;
            if (id == null)
            {
                result = false;

            }
            formularionomina formulario = DATABASE.formularionomina.Find(id);
            if (formulario != null)
            {
                DATABASE.formularionomina.Remove(formulario);
            }
            if (DATABASE.SaveChanges() > 0)
            {
                result = true;
            }
            return Json(result);


        }

        /*
        [HttpPost, ActionName("Delete")]
     //   [ValidateAntiForgeryToken]
        [Autenticado]
        public ActionResult Delete(int id)
        {
            formularionomina formulario = DATABASE.formularionomina.Find(id);
            DATABASE.formularionomina.Remove(formulario);
            DATABASE.SaveChanges();
            return RedirectToAction("Index");
        }
        */



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DATABASE.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}