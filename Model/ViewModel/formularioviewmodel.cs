using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Web.Mvc;

namespace Model.ViewModel
{
    public class formularioviewmodel
    {
        public formularionomina formulario { get; set; }
       // public IEnumerable<Objetal> Listobjetal { get; set; }
        public IEnumerable<SelectListItem> ObjetalList { get; set; }
        public IEnumerable<SelectListItem> ActividadList { get; set; }
        public IEnumerable<SelectListItem> TipodeCuentaList { get; set; }
        public IEnumerable<SelectListItem> MonedaList { get; set; }
        public IEnumerable<SelectListItem> Regionlist { get; set; }
        public IEnumerable<SelectListItem> ProvinciasList { get; set; }
        public IEnumerable<SelectListItem> MunicipioList { get; set; }
        public IEnumerable<SelectListItem> Cuentapresupestales { get; set; }
        public IEnumerable<SelectListItem> Funciones { get; set; }

    }
}
