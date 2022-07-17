using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Entity;

namespace DataAccess
{
    public class UserData
    {
        /// <summary>
        /// This method validates the username/password with the Users table in the database.If validation succeeds,
        /// it returns a valid User object,else it returns a null object.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User ValidateUser(string userName,string password)
        {
            User user = null;
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_ValidateUser");
            command.Parameters.Add(new SqlParameter("@UserName", userName));
            command.Parameters.Add(new SqlParameter("@Password", password));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                user = new User(Convert.ToInt32(reader["Id"].ToString()), reader["UserName"].ToString(), reader["FirstName"].ToString(),
                    reader["LastName"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsActive"].ToString()));
            }
            return user;
        }
    }
}
