namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Region")]
    public partial class Region
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

       [StringLength(10, ErrorMessage = "El codigo es no valido")]
        public string COD_REGION { get; set; }

     [StringLength(80, ErrorMessage = "El nombre no puede contener mas de 80 caracteres")]
        public string NOM_REGION { get; set; }
    }
}
