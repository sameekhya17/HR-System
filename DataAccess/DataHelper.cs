using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataHelper
    {
        /// <summary>
        /// This method establish a connection between .net and sql procedure.If the connection is not open,then it opens the connection or 
        /// else it create a new SqlCommand object.
        /// </summary>
        /// <param name="procedurename"></param>
        /// <returns></returns>
        internal static SqlCommand GetSqlCommandObject(string procedurename)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Silicon"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand (procedurename, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command;
        }
    }
}
