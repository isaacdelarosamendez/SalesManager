using SalesManager.Entities.Portal;
using SalesManager.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesManager.Web.Controllers
{
    public class MenuController : Controller
    {
        private usuarios ua = (usuarios)System.Web.HttpContext.Current.Session["usuario"];
        // GET: Menu

        public List<MenuViewModel> TraeMenu()
        {
            List<MenuViewModel> lstMenu = new List<MenuViewModel>();
            try
            {
                Core.Services.storedProcedures sp = new Core.Services.storedProcedures();
                lstMenu = sp.menuInicio(ua.usuario);
            }
            catch (Exception ex)
            {

               
            }
            return lstMenu;
        }

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}