using SuperstoreTool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperstoreTool.SQLConnection
{
    public class Connections
    {
        private string ConnectionString { get; set; }

        public Connections(string connectionString)
        {
            this.ConnectionString = connectionString;
        }   

        //Method to get from DB a list with the values needed in order to show sales by states and years
        //IMPORTANT! Use of ADO.NET to manage the access to the DB resources
        public IEnumerable<YearSales> GetSalesPerState()
        {
            using (SqlConnection dbConn = new SqlConnection(ConnectionString))
            {
                IEnumerable<YearSales> salesList;
                dbConn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_GetStateSales]", dbConn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    salesList = Utils.DataReader_DomEntry<YearSales>(reader);
                }
                return salesList;
            }
        }
    }
}
