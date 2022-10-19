using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperstoreTool.SQLConnection
{
    public static class DataAccess
    {
        public static string DbConnectionString = string.Empty;
        private static object _lock = new object();

        public static void SuperstoreServerConnectionUpdate(string connectionString)
        {
            lock (_lock)
            {
                DbConnectionString = connectionString;
            }
        }

        private static string GetConnectionString()
        {
            //if (string.IsNullOrEmpty(DbConnectionString)) DbConnectionString = ConfigurationManager.AppSettings[ConnectionStringAppSettingName];
            if (string.IsNullOrEmpty(DbConnectionString)) throw new Exception("THERE'S NO ACTIVE GEMOS SERVER !\nPLEASE CHECK 'KEEP ALIVE' APP!\nIF THE APP IS RUNNING CALL SUPPORT IMEDIATELY!");

            lock (_lock)
            {
                return DbConnectionString;
            }
        }

        public static Connections DOM_Connection()
        {
            return new Connections(DbConnectionString);
        }
    }
}
