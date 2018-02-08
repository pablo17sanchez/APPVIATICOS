using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model
{
    public partial class Tipo_de_cuenta
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        public string TIPO_CUENTA_CODIGO { get; set; }

        [StringLength(255)]
        public string TIPO_DESCRICION { get; set; }


    }
}
