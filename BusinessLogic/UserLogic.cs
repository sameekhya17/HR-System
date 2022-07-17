using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccess;

namespace BusinessLogic
{
    public class UserLogic
    {
        /// <summary>
        /// This method call the ValidateUser method of UserData class.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User ValidateUser(string userName, string password)
        {
            return UserData.ValidateUser(userName, password);
        }
    }
}
