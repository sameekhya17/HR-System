using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Entity;
using System.Data;
using System.Web;
using System.IO;

namespace DataAccess
{
    public class EmployeeData
    {
        /// <summary>
        /// Insertion of Employees.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="user"></param>
        public static void InsertEmployees(Employee employee, User user)
        {
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_InsertEmployees");
            SqlTransaction transaction = command.Connection.BeginTransaction();
            try
            {
                SqlParameter parameter = new SqlParameter("@Id", System.Data.SqlDbType.Int, 16);
                parameter.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(parameter);
                command.Parameters.Add(new SqlParameter("@TypeId", employee.EmployeeType.Id));
                command.Parameters.Add(new SqlParameter("@CategoryId", employee.Category.Id));
                command.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", employee.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", employee.LastName));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", employee.DateOfBirth));
                command.Parameters.Add(new SqlParameter("@DateOfJoining", employee.DateOfJoining));
                command.Parameters.Add(new SqlParameter("@UserId", user.Id));
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                employee.Id = Convert.ToInt32(command.Parameters["@Id"].Value.ToString());
                foreach (EmployeeDocument document in employee.EmployeeDocuments)
                {
                    if (document.IsActive)
                    {
                        InsertEmployeeDocument(employee.Id, document, transaction, command.Connection, user);
                    }
                }
                transaction.Commit();
            }
            catch(Exception exception)
            {
                transaction.Rollback();
                throw (exception);
            }
        }

        private static void InsertEmployeeDocument(int employeeId, EmployeeDocument employeeDocument, SqlTransaction transaction, SqlConnection connection, User user)
        {
            SqlCommand commandInsert = new SqlCommand("usp_InsertEmployeeDocument", connection);
            commandInsert.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter("@Id", System.Data.SqlDbType.Int, 16);
            parameter.Direction = System.Data.ParameterDirection.Output;
            commandInsert.Parameters.Add(parameter);
            commandInsert.Parameters.Add(new SqlParameter("@FileName", employeeDocument.FileName));
            commandInsert.Parameters.Add(new SqlParameter("@DocumentType", employeeDocument.DocumentType.Id));
            commandInsert.Parameters.Add(new SqlParameter("@Employee", employeeId));
            commandInsert.Parameters.Add(new SqlParameter("@UserId", user.Id));
            commandInsert.Transaction = transaction;
            commandInsert.ExecuteNonQuery();
            employeeDocument.Id = Convert.ToInt32(commandInsert.Parameters["@Id"].Value.ToString());
            string folderPath = HttpContext.Current.Server.MapPath(".") + @"\bin\EmployeeDocuments\" + employeeId.ToString() + @"\" +
                employeeDocument.DocumentType.Id + @"\" + employeeDocument.Id + @"\";
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            employeeDocument.PostedFile.SaveAs(folderPath + employeeDocument.PostedFile.FileName);
        }

        /// <summary>
        /// Update the Employee records.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="user"></param>
        public static void UpdateEmployees(Employee employee, User user)
        {
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_UpdateEmployees");
            SqlTransaction transaction = command.Connection.BeginTransaction();
            try
            {
                command.Parameters.Add(new SqlParameter("@Id", employee.Id));
                command.Parameters.Add(new SqlParameter("@TypeId", employee.EmployeeType.Id));
                command.Parameters.Add(new SqlParameter("@CategoryId", employee.Category.Id));
                command.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));
                command.Parameters.Add(new SqlParameter("@MiddleName", employee.MiddleName));
                command.Parameters.Add(new SqlParameter("@LastName", employee.LastName));
                command.Parameters.Add(new SqlParameter("@DateOfBirth", employee.DateOfBirth));
                command.Parameters.Add(new SqlParameter("@DateOfJoining", employee.DateOfJoining));
                command.Parameters.Add(new SqlParameter("@IsActive", employee.IsActive));
                command.Parameters.Add(new SqlParameter("@UserId", user.Id));
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                foreach (EmployeeDocument document in employee.EmployeeDocuments)
                {
                    if (document.Id < 0 && document.IsActive)
                    {
                        InsertEmployeeDocument(employee.Id, document, transaction, command.Connection, user);
                    }
                    else if (document.Id > 0 && document.IsDirty)
                    {
                        UpdateEmployeeDocument(document.Id, transaction, command.Connection);
                    }
                }
                transaction.Commit();
            }
            catch(Exception exception)
            {
                transaction.Rollback();
                throw (exception);
            }
        }

        private static void UpdateEmployeeDocument(int documentId, SqlTransaction transaction, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("usp_UpdateEmployeeDocument",connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", documentId));
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Get the list of only active employees.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="categoryId"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public static ArrayList SearchActiveEmployees(int typeId, int categoryId, string employeeName)
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_SearchActiveEmployees");
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@TypeId", typeId));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@EmployeeName", employeeName));
            adapter.Fill(records);
            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    EmployeeType type = new EmployeeType(Convert.ToInt32(row["EmployeeTypeId"].ToString()), row["EmployeeType"].ToString());
                    EmployeeCategory category = new EmployeeCategory(Convert.ToInt32(row["EmployeeCategoryId"].ToString()), row["EmployeeCategory"].ToString());

                    list.Add(new Employee(Convert.ToInt32(row["Id"].ToString()), row["FirstName"].ToString(), row["MiddleName"].ToString(), row["LastName"].ToString(),
                        category, type, Convert.ToDateTime(row["DateOfJoining"].ToString()), Convert.ToDateTime(row["DateOfBirth"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString(),
                        Convert.ToBoolean(row["IsActive"].ToString())));
                }
            }
            return list;
        }

        /// <summary>
        /// Get the list of all the Employees.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="categoryId"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        public static ArrayList SearchEmployees(int typeId, int categoryId, string employeeName)
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_SearchEmployees");
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@TypeId", typeId));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@EmployeeName", employeeName));
            adapter.Fill(records);
            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    EmployeeType type = new EmployeeType(Convert.ToInt32(row["EmployeeTypeId"].ToString()), row["EmployeeType"].ToString());
                    EmployeeCategory category = new EmployeeCategory(Convert.ToInt32(row["EmployeeCategoryId"].ToString()), row["EmployeeCategory"].ToString());

                    list.Add(new Employee(Convert.ToInt32(row["Id"].ToString()), row["FirstName"].ToString(), row["MiddleName"].ToString(), row["LastName"].ToString(),
                        category, type, Convert.ToDateTime(row["DateOfJoining"].ToString()), Convert.ToDateTime(row["DateOfBirth"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString(),
                        Convert.ToBoolean(row["IsActive"].ToString())));
                }
            }
            return list;
        }

        /// <summary>
        /// Get the Id of Employees.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Employee GetEmployeeById(int id)
        {
            DataSet records = new DataSet();
            Employee employee = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetEmployeeById");
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", id));
            adapter.Fill(records);
            if (records != null && records.Tables[0].Rows.Count == 1)
            {
                DataRow row = records.Tables[0].Rows[0];
                EmployeeType type = new EmployeeType(Convert.ToInt32(row["EmployeeTypeId"].ToString()), row["EmployeeType"].ToString());
                EmployeeCategory category = new EmployeeCategory(Convert.ToInt32(row["EmployeeCategoryId"].ToString()), row["EmployeeCategory"].ToString());

                employee = new Employee(Convert.ToInt32(row["Id"].ToString()), row["FirstName"].ToString(), row["MiddleName"].ToString(), row["LastName"].ToString(),
                    category, type, Convert.ToDateTime(row["DateOfJoining"].ToString()), Convert.ToDateTime(row["DateOfBirth"].ToString()),
                    row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString(),
                    Convert.ToBoolean(row["IsActive"].ToString()));
            }
            employee.EmployeeDocuments = GetDocumentsByEmployeeId(employee.Id);
            return employee;
        }

        private static ArrayList GetDocumentsByEmployeeId(int employeeId)
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetDocumentsByEmployeeId");
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", employeeId));
            adapter.Fill(records);
            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    DocumentType type = new DocumentType(Convert.ToInt32(row["DocumentTypeId"].ToString()), row["DocumentType"].ToString());

                    list.Add(new EmployeeDocument(Convert.ToInt32(row["Id"].ToString()), row["FileName"].ToString(), type,
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString(),
                        Convert.ToBoolean(row["IsActive"].ToString())));
                }
            }
            return list;
        }
    }
}
