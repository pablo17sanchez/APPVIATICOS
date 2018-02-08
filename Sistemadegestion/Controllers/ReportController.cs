using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Text;
namespace Sistemadegestion.Controllers
{
    public class ReportController : Controller
    {

        DB database = new DB();

        public ActionResult Index()
        {



            return View();
        }


        public FileStreamResult SaveData(DateTime fdesde, DateTime fhasta)
        {


            String example="";
       
          


            

            var result = from a in database.formularionomina
                         where
                        (a.FechaActual >= fdesde && a.FechaActual <= fhasta)
                         select a;


        

            foreach (var row in result)
            {
              

                example +=     row.FechaNomina.Value.Year.ToString() + " " + row.Capitulo.ToString() + " " + row.Subcapitulo.ToString() + " " + row.Programa.ToString() + " " + row.Subprograma.ToString() + " " + row.Proyecto.ToString() + " " + row.Actividad.ToString() + " " + "COD_SNIP" + " " + "COD_FUENTE_ESPECIFICA" + " " + "COD_ORG_FINANCIADOR"+" "+row.Funcion.ToString()+" "+row.CCP.ToString()+" "+row.Region.ToString()+" "+row.Provincia.ToString()+" "+row.Municipio.ToString()+" "+"CODIGO_TRASFERENCIA"+" "+"COD_TRF"+" "+row.Objeto.ToString()+" "+row.Identificacion.ToString()+" "+row.Beneficiario.ToString()+" "+row.Codigodepartamento.ToString()+" "+row.Tarjeta.ToString()+" "+row.tipo_de_cuenta.ToString()+" "+row.UE.ToString()+" "+row.Nodecuentabancaria.ToString()+" "+row.DAF.ToString()+" "+row.Codigo_de_moneda.ToString()+" "+row.Concepto.ToString()+ Environment.NewLine;

         

            }

               

            var byteArray = Encoding.UTF8.GetBytes(example);
           
            var stream = new MemoryStream(byteArray);







       
            return File(stream, "text/plain", String.Format("{0}.txt", "ReporteViaticos"));
        }
    }
}