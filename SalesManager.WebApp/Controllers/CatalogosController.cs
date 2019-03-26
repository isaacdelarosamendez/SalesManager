﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesManager.WebApp.Controllers
{
    public class CatalogosController : Controller
    {
        Core.Services.CatalogosServices catalogosServices = new Core.Services.CatalogosServices();

        public IActionResult Index(int? id)
        {
            var model = catalogosServices.GetEntidad((int)id);
            return View(model);
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
                int entidadId = Convert.ToInt32(HttpContext.Request.Form["entidadId"]);
                //ID  de la tabla
                string tabla = HttpContext.Request.Form["tabla"];
                //QUERY PRINCIPAL
                string query = "INSERT INTO ";
                query += tabla;
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
                        query += name + ",";
                        //Se obtiene el valor del atributo
                        var value = HttpContext.Request.Form[item.ToString()];
                        switch (type)
                        {
                            case "number":
                                datos += value + ",";
                                break;
                            default:
                                datos += "'" + value + "',";
                                break;
                        }
                    }

                }
                query = query.Substring(0, query.Length - 1);
                query += ")";
                datos = datos.Substring(0, datos.Length - 1);
                datos += ")";
                //query final
                query += datos;

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Json(result);
        }
    }
}