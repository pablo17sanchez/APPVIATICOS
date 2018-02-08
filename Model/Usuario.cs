namespace Model
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
     
        [Key,Column("id")]
        public int userid { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(11,MinimumLength=11,ErrorMessage="Cedula no validad")]
        public string Cedula { get; set; }

        public virtual ICollection<formularionomina> formularionomina { get; set; }

        public ResponseModel Acceder(string Username, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new DB())
                {
                    Password = HashHelper.MD5(Password);

                    var usuario = ctx.Usuarios.Where(x => x.Username == Username)
                                             .Where(x => x.Password == Password)
                                             .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.userid.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña incorrecta");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }



        public Usuario Obtener(int id)
        {
            var usuario = new Usuario();

            try
            {
                using (var ctx = new DB())
                {


                    usuario = ctx.Usuarios.Where(x => x.userid == id)
                                         .SingleOrDefault();



                    // Trayendo un registro adicional de manera manual, sin usar Include
                    // usuario.Pais = new TablaDato().Obtener("pais", usuario.Pais_id.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }

            return usuario;
        }


      
    }
}
