using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Core.Services
{
    public class LoginServices
    {
        private SalesManager.Models.DB.Entities db = new SalesManager.Models.DB.Entities();

        /// <summary>
        /// Retorna una instancia de la clase usuario, si no existe el usuario, regresa un valor null
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public Models.DB.usuarios GetUsuario(string u, string p)
        {
            try
            {
                var phash = Security.Encriptar(p);
                if (db.usuarios.Any(s => s.usuario.ToUpper().Trim().Equals(u.ToUpper().Trim()) && s.password.Equals(phash)))
                {
                    return db.usuarios.FirstOrDefault(s => s.usuario.ToUpper().Trim().Equals(u.ToUpper().Trim()));
                }
                else {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
