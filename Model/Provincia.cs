namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Provincia
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

  
        [StringLength(10, ErrorMessage = "El codigo es no valido")]
        [Required(ErrorMessage="Campo Obligatorio")]
        public string COD_REGION { get; set; }

        [StringLength(10,ErrorMessage="El codigo es no valido")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string COD_PROVINCIA { get; set; }

        [StringLength(255)]
        public string NOM_PROVINCIA { get; set; }



    }
}
