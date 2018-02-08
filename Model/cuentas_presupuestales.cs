namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cuentas_presupuestales
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(12)]
        public string COD_CUENTA_PRESUP { get; set; }

        [StringLength(45)]
        public string DES_CUENTA_PRESUP { get; set; }
    }
}
