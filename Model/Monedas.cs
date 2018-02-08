using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Model
{
    public partial class Monedas
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(10)]
        public string CODIGO_MONEDA { get; set; }


        [StringLength(80)]
        public string MONEDA_DESCRIPCION { get; set; }


        
    }
}
