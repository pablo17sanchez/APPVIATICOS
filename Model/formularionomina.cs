using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace Model
{
    public class formularionomina
    {
        //402-2096515-2


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(14, ErrorMessage = "El numero de identificacion no puede pasar del caracter")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [MinLength(11, ErrorMessage = "Debe digitar una cedula valida")]
        [MaxLength(12, ErrorMessage = "Debe digitar una cedula valida")]
        public String Identificacion { get; set; }
        [DisplayName("Tipo Identificacion")]
        //Listo
        public String Tipo_identificacion { get; set; }
        public String Capitulo { get; set; }
        public String Subcapitulo { get; set; }
        public String DAF { get; set; }
        public String UE { get; set; }
        public String Programa { get; set; }
        public String Subprograma { get; set; }
        public String Proyecto { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El campo tiene que tener una longitud  comprendida entre 1 y 20")]
        public String Actividad { get; set; }
        public String Objeto { get; set; }
        public String Fondo { get; set; }
        [DisplayName("Organismo Financiador")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El campo tiene que tener una longitud  comprendida entre 1 y 5")]
        public String Organismo_Financiador { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String Tarjeta { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]

        public String codigo_del_banco { get; set; }
        public String tipo_de_cuenta { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String Nodecuentabancaria { get; set; }
        public String Codigo_de_moneda { get; set; }

        public DateTime? FechaActual { get; set; }
        [StringLength(37, MinimumLength = 1, ErrorMessage = "El campo tiene que tener una longitud  comprendida entre 1 y 37")]
        [DataType(DataType.Text, ErrorMessage = "El campo tiene que ser de tipo texto")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String Beneficiario { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(37, MinimumLength = 1, ErrorMessage = "El campo tiene que tener una longitud  comprendida entre 1 y 30")]
        public String Cargo { get; set; }
        [DataType(DataType.MultilineText)]
        public String Concepto { get; set; }
        public String Cedula { get; set; }

        [DisplayName("Fecha Nomina")]
        [Column(TypeName = "datetime2")]
        public DateTime? FechaNomina { get; set; }
        [DisplayName("Nombre del departamento")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String NombredelDepartamento { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String Codigodepartamento { get; set; }
        [DisplayName("Codigo del cargo")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Codigocargo { get; set; }
        [Required(ErrorMessage = "Por favor seleccione una region")]
        public String Region { get; set; }
        [Required(ErrorMessage = "Por favor Seleccione una privincia")]

        public String Provincia { get; set; }
        [Required(ErrorMessage = "Por favor Seleccione una privincia")]

        public String Municipio { get; set; }
        public int Funcion { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public Decimal MontoViatico { get; set; }
        public int CCP { get; set; }
        public int userid { get; set; }

        public virtual Usuario Usuario { get; set; }



        public formularionomina()
        {
            this.FechaActual = Convert.ToDateTime(DateTime.Now.ToString());
            this.FechaNomina = Convert.ToDateTime(DateTime.Now.ToString());
            this.Capitulo = "0206";
            this.UE = "0010";
            this.Subcapitulo = "01";
            this.DAF = "01";
            this.Programa = "16";
            this.Subprograma = "00";
            this.Proyecto = "00";
            this.Fondo = "00100";
            this.Organismo_Financiador = "100";
            this.Codigo_de_moneda = "DOP";
            this.Tipo_identificacion = "cedula";
            this.Codigocargo = 0;
            this.Codigodepartamento = "0";
            this.userid = SessionHelper.GetUser();
            this.codigo_del_banco = "10101010106";
            this.Tarjeta = "";
            this.Cedula = "";
            this.tipo_de_cuenta = "CAH";


        }









        public AnexGRIDResponde Listar(AnexGRID grid, int Usuario_id)
        {
            try
            {
                using (var ctx = new DB())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.formularionomina.Where(x => x.Id > 0);


                    // Ordenamiento
                    if (grid.columna == "Identificacion")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Identificacion)
                                                             : query.OrderBy(x => x.Identificacion);
                    }

                    if (grid.columna == "Tipo_identificacion")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Tipo_identificacion)
                                                             : query.OrderBy(x => x.Tipo_identificacion);
                    }

                    if (grid.columna == "Capitulo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Capitulo)
                                                             : query.OrderBy(x => x.Capitulo);
                    }

                    if (grid.columna == "Cargo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Cargo)
                                                             : query.OrderBy(x => x.Cargo);
                    }

                    if (grid.columna == "Beneficiario")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Beneficiario)
                                                             : query.OrderBy(x => x.Beneficiario);
                    }

                    // id, Nombre, Titulo, Desde, Hasta

                    var experiencias = query.Skip(grid.pagina)
                                            .Take(grid.limite)
                                             .ToList();

                    var total = query.Count();

                    grid.SetData(experiencias, total);
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return grid.responde();
        }






    }







}
