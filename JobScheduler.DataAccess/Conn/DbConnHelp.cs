using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace JobScheduler.DataAccess.Conn
{
    public class DbConnHelp
    {
        /// <summary>
        ///  GetDbConnection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection<T>(string conn)
        {
            IDbConnection connInstance = null;
            if (!string.IsNullOrWhiteSpace(conn))
            {
                if (typeof(T) == typeof(MySqlConnection))
                {
                    connInstance = new MySqlConnection(conn);
                }
                else if (typeof(T) == typeof(SqlConnection))
                {
                    connInstance = new SqlConnection(conn);
                }
            }

            if (connInstance != null)
            {
                connInstance.Open();
            }

            return connInstance;
        }
    }
}
