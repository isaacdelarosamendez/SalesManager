using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesManager.Web.Controllers
{
    public class CatalogosController : Controller
    {
        private Core.Services.CatalogosServices catalogosServices = new Core.Services.CatalogosServices();
        private Core.Services.storedProcedures storedProcedures = new Core.Services.storedProcedures();

        #region Views
        public ActionResult Index(int? id)
        {
            var model = catalogosServices.GetEntidad((int)id);
            return View(model);
        }

        public ActionResult Create(int? id)
        {
            var model = catalogosServices.GetEntidad((int)id);
            return View(model);
        }

        public ActionResult Update(int id, int itemID)
        {
            var model = catalogosServices.GetEntidad((int)id);
            Models.DB.entidades entidad = catalogosServices.GetEntidad(id);
            DataSet ds = storedProcedures.GetResulQuery(entidad.queryUpdate.Replace("{{id}}",itemID.ToString()));
            DataTable result = new DataTable();
            if (ds != null)
            {
                result = ds.Tables[0];
            }
            List<Dictionary<string, object>> lstResult = storedProcedures.GetTableRows(result);
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            var userInfoJson = jss.Serialize(lstResult);
            ViewBag.Data = userInfoJson;
            return View(model);
        }
        #endregion

        /// <summary>
        /// Devuelve un listado de la entidad CombosDinamicos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetValuesByQuery(string query)
        {
            List<Entities.Formularios.CombosDinamicos> result = new List<Entities.Formularios.CombosDinamicos>();
            try
            {
                result = storedProcedures.GetValuesFromQuery(query);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(result,JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetValuesTable(string query, int entidadId)
        {
            DataTable result = new DataTable();
            try
            {
                Models.DB.entidades entidad = catalogosServices.GetEntidad(entidadId);
                DataSet ds = storedProcedures.GetResulQuery(entidad.query);
                if (ds != null)
                {
                    result = ds.Tables[0];
                }
                List<Dictionary<string, object>> lstResult = storedProcedures.GetTableRows(result);
                return Json(lstResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Funcion que crea un query para realizar una insercion de manera dinamica
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create()
        {

            string result = "";
            try
            {            
                //ID de la entidad
                int entidadId = Convert.ToInt32(Request["entidadId"]);
                //ID  de la tabla
                string tabla = Request["tabla"];
                //QUERY PRINCIPAL
                string query = "INSERT INTO ";
                query += tabla +" (";
                //QUERY QUE OBTIENE LOS DATOS
                string datos = " VALUES(";

                //Se obtiene todoslos atributos del formulario
                foreach (var item in Request.Form.Keys)
                { 
                    //Se valida el atributo no sea el nombre de la tabla, ni el ID de la entidad ni el Header de ajax

                    if (!item.ToString().Equals("tabla") && !item.ToString().Equals("entidadId") && !item.ToString().Equals("X-Requested-With"))
                    {

                        //Se obtiene el nombre del atributo
                        var name = item.ToString().Split('|')[0];
                        //Se obtiene el tipo de atributo
                        var type = item.ToString().Split('|')[1];
                        if (!type.Equals("hidden"))
                        {
                            query += name + ",";
                            //Se obtiene el valor del atributo
                            var value = Request[item.ToString()];
                            if (type.Equals("checkbox"))
                            {
                                value = value.Equals("false") ? "0" : "1";
                            }
                            if (type.Equals("select"))
                            {
                                value = value.Equals("0") ? "NULL" : value;
                            }
                            switch (type)
                            {
                                case "number":
                                case "checkbox":
                                case "select":
                                    datos += value + ",";
                                    break;
                                default:
                                    datos += "'" + value + "',";
                                    break;
                            }
                        }
                        
                    }

                }
                query = query.Substring(0,query.Length-1);
                query += ")";
                datos = datos.Substring(0, datos.Length - 1);
                datos += ")";
                //query final
                query += datos;

                result = catalogosServices.Create(query);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }

        /// <summary>
        /// Funcion que crea un query para realizar un update de manera dinamica
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update()
        {

            string result = "";
            try
            {
                //ID de la entidad
                int entidadId = Convert.ToInt32(Request["entidadId"]);
                //ID  de la tabla
                string tabla = Request["tabla"];
                //QUERY PRINCIPAL
                string query = "UPDATE  ";
                query += tabla + " SET ";

                decimal PKValue = 0;
                //Se obtiene todoslos atributos del formulario
                foreach (var item in Request.Form.Keys)
                {
                    //Se valida el atributo no sea el nombre de la tabla, ni el ID de la entidad ni el Header de ajax

                    if (!item.ToString().Equals("tabla") && !item.ToString().Equals("entidadId") && !item.ToString().Equals("X-Requested-With"))
                    {

                        //Se obtiene el nombre del atributo
                        var name = item.ToString().Split('|')[0];
                        //Se obtiene el tipo de atributo
                        var type = item.ToString().Split('|')[1];

                        //Se obtiene el valor del atributo
                        var value = Request[item.ToString()];

                        if (type.Equals("hidden"))
                        {
                            PKValue = Convert.ToDecimal(value);
                        }
                        else {
                            if (type.Equals("checkbox"))
                            {
                                value = value.Equals("false") ? "0" : "1";
                            }
                            if (type.Equals("select"))
                            {
                                value = value.Equals("0") ? "NULL" : value;
                            }
                            switch (type)
                            {
                                case "number":
                                case "checkbox":
                                case "select":
                                    query += name + "=" + value + ",";
                                    break;
                                default:
                                    query += name + "='" + value + "',";
                                    break;
                            }
                        }

                    }

                }

                query = query.Substring(0, query.Length - 1);
                Models.DB.entidades entidad = catalogosServices.GetEntidad(entidadId);
                query += " WHERE " + entidad.PK + "="+ PKValue.ToString();
                result = catalogosServices.Create(query);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
    }
}