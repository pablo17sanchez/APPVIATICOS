using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.ViewModel;
using System.Web.Mvc;
using System.Web;




namespace Repository
{
    public class formularioaccessread
    {
        DB DATABASE = new DB();


        public IEnumerable<SelectListItem> GetObjetales()
        {

         var v=   DATABASE.Objetals.ToList();

          IEnumerable<SelectListItem> objetales = v
                                              .Select(i => new SelectListItem()
                                              {
                                                  Text = i.nombre_objetal,
                                                  Value = i.codigo_objetal
                                              });

          return new SelectList(objetales, "Value", "Text");

       
            

            
        }




        public IEnumerable<SelectListItem> GetActividades()
        {

            var v = DATABASE.Actividad.ToList();

            IEnumerable<SelectListItem> actividades = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.DESC_ACTIVIDAD,
                                                    Value = i.COD_ACTIVIDAD
                                                });

            return new SelectList(actividades, "Value", "Text");





        }



        public IEnumerable<SelectListItem> GetTipodeCuenta()
        {

            var v = DATABASE.Tipo_de_cuenta.ToList();

            IEnumerable<SelectListItem> tipos_de_cuentas = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.TIPO_DESCRICION,
                                                    Value = i.TIPO_CUENTA_CODIGO
                                                });

            return new SelectList(tipos_de_cuentas, "Value", "Text");





        }

        public IEnumerable<SelectListItem> GetMoneda()
        {

            var v = DATABASE.Moneda.ToList();

            IEnumerable<SelectListItem> tipos_de_cuentas = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.MONEDA_DESCRIPCION,
                                                    Value = i.CODIGO_MONEDA
                                                });

            return new SelectList(tipos_de_cuentas, "Value", "Text");





        }

        public IEnumerable<SelectListItem> GetRegion()
        {

            var v = DATABASE.Regions.ToList();

            IEnumerable<SelectListItem> region = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.NOM_REGION,
                                                    Value = i.COD_REGION
                                                });

            return new SelectList(region, "Value", "Text");





        }



        public IEnumerable<SelectListItem> GetMunicipios()
        {

            var v = DATABASE.Municipios.ToList();

            IEnumerable<SelectListItem> municipios = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.NOM_MUNICIPIO,
                                                    Value = i.COD_MUNICIPIO
                                                });

            return new SelectList(municipios, "Value", "Text");





        }


        public IEnumerable<SelectListItem> GetProvincias()
        {
            


            var v = DATABASE.Provincias.ToList();




            IEnumerable<SelectListItem> provincias = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.NOM_PROVINCIA,
                                                    Value = i.COD_PROVINCIA
                                                });

            return new SelectList(provincias, "Value", "Text");





        }

         /*public IEnumerable<SelectListItem> GetProvinciasconparametro(int regionid)
        {
            int resultado = (regionid ==null) ? 0 : regionid ;

            var v = DATABASE.Provincias.Where(x=>x.COD_REGION == Convert.ToString(regionid) )).ToList();


            




            IEnumerable<SelectListItem> provincias = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.NOM_PROVINCIA,
                                                    Value = i.COD_PROVINCIA
                                                });

            return new SelectList(provincias, "Value", "Text");





        }*/



        public IEnumerable<SelectListItem> GetFunciones()
        {

            var v = DATABASE.Funciones.ToList();

            IEnumerable<SelectListItem> funciones = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.DESCRIPCION_FUNCION,
                                                    Value = i.CODIGO_FUNCIONES
                                                });

            return new SelectList(funciones, "Value", "Text");





        }

        public IEnumerable<SelectListItem> GetCuentaPresupuestales()
        {

            var v = DATABASE.cuentas_presupuestales.ToList();

            IEnumerable<SelectListItem> cuenta_presupuestales = v
                                                .Select(i => new SelectListItem()
                                                {
                                                    Text = i.DES_CUENTA_PRESUP,
                                                    Value = i.COD_CUENTA_PRESUP
                                                });

            return new SelectList(cuenta_presupuestales, "Value", "Text");





        }



/*
        public List<Provincia> GetPROVINCIA(int regionid)
        { 
        
        int resultado = (regionid ==null) ? 0 : regionid ;


         string resutado_convertido = Convert.ToString(regionid) ;

         var v = DATABASE.Provincias.Where(x => x.COD_REGION == resutado_convertido).Select(x=> new  {Text=x.NOM_PROVINCIA,Value=x.COD_PROVINCIA}).ToList();

         return v;

        }*/

    }
}
