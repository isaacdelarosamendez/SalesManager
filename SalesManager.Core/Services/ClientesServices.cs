using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Core.Services
{
    public class ClientesServices
    {
        private Models.DB.Entities db = new Models.DB.Entities();

        /// <summary>
        /// Agrega una nueva instancia de CLIENTES
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public string Create(Models.DB.clientes cliente)
        {
            try
            {
                db.clientes.Add(cliente);
                db.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
