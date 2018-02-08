using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model
{
    public partial class Actividad
    {
        [Key]
        public int id { get; set; }

        [StringLength(255)]
        public string COD_ACTIVIDAD{ get; set; }

        [StringLength(255)]
        public string DESC_ACTIVIDAD { get; set; }
    }
}
