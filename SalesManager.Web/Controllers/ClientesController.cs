using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesManager.Models.DB;

namespace SalesManager.Web.Controllers
{
    public class ClientesController : Controller
    {
        SalesManager.Models.DB.usuarios ua = (SalesManager.Models.DB.usuarios)System.Web.HttpContext.Current.Session["usuario"];
        private Models.DB.Entities db = new Models.DB.Entities();
        private Core.Services.ClientesServices clientes = new Core.Services.ClientesServices();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.clientes.Where(s => s.activo==true).OrderBy(s => s.nombre).Include(c => c.municipios).Include(c => c.usuarios);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.municipioId = new SelectList(db.municipios, "municipioId", "municipioId");
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "GUID");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clienteId,nombre,razonSocial,margen,monto,direccion,municipioId,observaciones,esProspecto,ubicacion, latitud, longitud")] clientes cliente)
        {
            try
            {
                cliente.usuarioId = ua.usuarioId;
                cliente.activo = true;
                if (ModelState.IsValid)
                {

                    return Json(clientes.Create(cliente));
                }
                else
                {
                    return Json("Favor de validar los campos ingresados");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.municipioId = new SelectList(db.municipios, "municipioId", "municipioId", clientes.municipioId);
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "GUID", clientes.usuarioId);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clienteId,nombre,razonSocial,margen,monto,direccion,municipioId,observaciones,esProspecto,ubicacion,usuarioId,activo")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.municipioId = new SelectList(db.municipios, "municipioId", "municipioId", clientes.municipioId);
            ViewBag.usuarioId = new SelectList(db.usuarios, "usuarioId", "GUID", clientes.usuarioId);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            clientes clientes = db.clientes.Find(id);
            db.clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
