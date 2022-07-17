using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccess;

namespace BusinessLogic
{
    public class EmployeeLogic
    {
        /// <summary>
        /// This method call the InsertEmployees method of EmployeeData class.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="user"></param>
        public static void InsertEmployees(Employee employee, User user)
        {
            EmployeeData.InsertEmployees(employee, user);
        }

        /// <summary>
        /// This method call the UpdateEmployees method of EmployeeData class.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="user"></param>
        public static void UpdateEmployees(Employee employee, User user)
        {
            EmployeeData.UpdateEmployees(employee, user);
        }

        /// <summary>
        /// This method keep the list of SearchActiveEmployees.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="categoryId"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public static ArrayList SearchActiveEmployees(int typeId, int categoryId, string employeeName)
        {
            return EmployeeData.SearchActiveEmployees(typeId,categoryId,employeeName);
        }

        /// <summary>
        /// This method keep the list of SearchEmployees.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="categoryId"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public static ArrayList SearchEmployees(int typeId, int categoryId, string employeeName)
        {
            return EmployeeData.SearchEmployees(typeId, categoryId, employeeName);
        }

        /// <summary>
        /// This method call the GetEmployeeById method of EmployeeData class.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Employee GetEmployeeById(int id)
        {
            return EmployeeData.GetEmployeeById(id);
        }
    }
}
