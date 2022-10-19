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

        public IEnumerable<Product> GetAll()
        {
            using (SqlConnection dbConn = new SqlConnection(ConnectionString))
            {
                IEnumerable<Product> productList;
                dbConn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[GetProducts]", dbConn);

                cmd.CommandType = CommandType.StoredProcedure;
                    
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    productList = Utils.DataReader_DomEntry<Product>(reader);
                }

                return productList;

            }
        }


        public IEnumerable<YearSales> GetSalesPerState()
        {
            using (SqlConnection dbConn = new SqlConnection(ConnectionString))
            {
                IEnumerable<YearSales> salesList;
                dbConn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[GetStateSales]", dbConn);

                cmd.CommandType = CommandType.StoredProcedure;

                //if (yearSelected != null)
                //    cmd.Parameters.Add(new SqlParameter("@year", yearSelected));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    salesList = Utils.DataReader_DomEntry<YearSales>(reader);
                }

                return salesList;

            }
        }
    }
}
