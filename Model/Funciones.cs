
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model
{
    public class Funciones
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

     
        [StringLength(10, ErrorMessage = "El codigo es no valido")]
        public string CODIGO_FUNCIONES { get; set; }


        [StringLength(80,ErrorMessage="El nombre no puede contener mas de 80 caracteres")]
        public string DESCRIPCION_FUNCION { get; set; }




    }



}
