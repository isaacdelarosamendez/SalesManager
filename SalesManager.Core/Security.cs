using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Core
{
    public class Security
    {
        private static Models.DB.Entities db = new Models.DB.Entities();

        /// <summary>
        /// Regresa un valor String encriptado
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static String Encriptar(string valor)
        {
            try
            {
                string result = db.spq_Encriptar(valor).ToList()[0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        /// <summary>
        /// Regresa un valor String desencriptado
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static String Desencriptar(string valor)
        {
            try
            {
                string result = db.spq_Desencriptar(valor).ToList()[0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
