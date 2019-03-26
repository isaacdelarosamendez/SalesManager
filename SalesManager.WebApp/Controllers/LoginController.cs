using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesManager.WebApp.Controllers
{
    public class LoginController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Funcion que inicia sesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult InicioSesion()
        {
            string result = "";
            try
            {
                string usuario = HttpContext.Request.Form["us"].ToString();
                string contraseña = HttpContext.Request.Form["pw"].ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Json(result);
        }
    }
}