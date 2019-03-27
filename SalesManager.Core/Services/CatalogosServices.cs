using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Core.Services
{
    public class CatalogosServices
    {
        private Models.DB.Entities db = new Models.DB.Entities();

        /// <summary>
        /// Devuelve una instancia de la clase Entidad
        /// </summary>
        /// <returns></returns>
        public Models.DB.entidades GetEntidad(int ID)
        {
            try
            {
                Models.DB.entidades entidad = db.entidades.FirstOrDefault(s => s.entidadId == ID);
                return entidad;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Inserta una nueva entidad dinamica mediante un query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public String Create(string query)
        {
            try
            {
                int rowsAffected = db.Database.ExecuteSqlCommand(query);
                return rowsAffected > 0 ? "" : "Ocurrio un problema durante la inserción";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       
    }
}
