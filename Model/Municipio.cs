namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Municipio
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

    
        [StringLength(10, ErrorMessage = "El codigo es no valido")]
        public string COD_REGION { get; set; }

    
        [StringLength(10, ErrorMessage = "El codigo es no valido")]
        public string COD_PROVINCIA { get; set; }

      
        [StringLength(10, ErrorMessage = "El codigo es no valido")]
        public string COD_MUNICIPIO { get; set; }

        [StringLength(80)]
        public string NOM_MUNICIPIO { get; set; }
    }
}
