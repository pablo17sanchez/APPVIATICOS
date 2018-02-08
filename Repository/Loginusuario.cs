using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Helper;
namespace Repository
{
   public static class Loginusuario
    {

        public static ResponseModel Acceder(string username, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new DB())
                {
                    Password = HashHelper.MD5(Password);

                    var usuario = ctx.Usuarios.Where(x => x.Username == username)
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


        





    }
}
