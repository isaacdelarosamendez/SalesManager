using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
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

        public List<Entities.Formularios.CombosDinamicos> GetValuesFromQuery(string query)
        {
            return db.Database.SqlQuery<Entities.Formularios.CombosDinamicos>(query).ToList();
        }
   
        public DataSet GetResulQuery(string query)
        {
            try
            {
                DataSet retVal = new DataSet();
                SqlConnection sqlConn = new SqlConnection(db.Database.Connection.ConnectionString);
                SqlCommand cmdReport = new SqlCommand(query, sqlConn);
                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(retVal);
                }
                return retVal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>>
            lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }
    }
}
