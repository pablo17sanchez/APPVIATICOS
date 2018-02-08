using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model
{
    public partial class MontosViaticos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }



        public int CODIGODEGRUPO { get; set; }

        public decimal MONTO { get; set; }






    }
}
