namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Objetal")]
    public partial class Objetal
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El codigo es no valido")]
        public string codigo_objetal { get; set; }
        
        [Required]
        [StringLength(45,ErrorMessage="El nombre no puede sobrepasar los 45 caracteres")]
        public string nombre_objetal { get; set; }

      /*  [Required]
        public Guid DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
       // public virtual Departamento Departamento { get; set; }*/
    }
}
