using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManager.Entities.Portal;
namespace SalesManager.Core.Services
{
    public class storedProcedures
    {
        private Models.DB.Entities db = new Models.DB.Entities();
        public List<Entities.Portal.MenuViewModel> menuInicio(string usuario)
        {
            return db.Database.SqlQuery<MenuViewModel>("sp_menuMVC @pusuario",
                new SqlParameter("@pusuario", usuario)).ToList();
        }
    }
}
