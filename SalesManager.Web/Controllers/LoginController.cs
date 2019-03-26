using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesManager.Web.Controllers
{
    public class LoginController : Controller
    {
        private Core.Services.LoginServices services = new Core.Services.LoginServices();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Funcion que inicia sesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InicioSesion()
        {
            string result = "";
            try
            {
                string usuario = Request["us"].ToString();
                string contraseña = Request["pw"].ToString();

                Models.DB.usuarios currentUser = services.GetUsuario(usuario,contraseña);
                if (currentUser == null)
                {
                    result = "Sus credenciales no son validas";
                }
                else {
                    System.Web.HttpContext.Current.Session["usuario"] = currentUser;
                }

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }
    }
}