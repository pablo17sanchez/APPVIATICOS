using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Helper;
using proyecto.Areas.Admin.Filters;
using Model;
using System.Web.Security;
namespace Sistemadegestion.Controllers
{
    public class LoginController : Controller
    {
        DB database = new DB();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }




      
        public ActionResult Acceder(string Username, string Password)
         {
            var rm = Loginusuario.Acceder(Username, Password);

            if (rm.response)
            {


              //  FormsAuthentication.SetAuthCookie(Username,true);
               return RedirectToAction("Create", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

           
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return RedirectToAction("Index", "Login");
        }


        public ActionResult Create(Usuario usuario ) {


            try
            {

                if (ModelState.IsValid)
                {

                    usuario.Password = HashHelper.MD5(usuario.Password);

                    database.Usuarios.Add(usuario);
                    database.SaveChanges();
                    
                }

                

               


            }
            catch (Exception es)
            {

                return HttpNotFound();
                
                throw;
            }






            return View();

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