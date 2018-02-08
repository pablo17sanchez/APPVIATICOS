using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{


    public partial class Personal
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(11, ErrorMessage = "El codigo es no valido")]
        public string Cedula { get; set; }


        [StringLength(80, ErrorMessage = "El codigo es no valido")]
        public string NombreYApellido { get; set; }


        [StringLength(40, ErrorMessage = "El codigo es no valido")]
        public string CuentaBancaria { get; set; }

        [StringLength(40, ErrorMessage = "El codigo es no valido")]
        public string Cargo { get; set; }
        
        
        [Required]
        [StringLength(40, ErrorMessage = "Departamento no valido")]
        public String Departamento { get; set; }
   
        [StringLength(40, ErrorMessage = "El codigo es no valido")]
        public String grupo_ocupacional { get; set; }
        public int Codigo_de_grupo_ocupacional { get; set; }

        public Decimal MontoViaticos { get; set; }
    }
}
