using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Entity;
using System.Data;

namespace DataAccess
{
    public class MasterData
    {
        #region Employee Type Methods

        /// <summary>
        /// Get all the EmployeeType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetAllEmployeeType()
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetAllEmployeeType");
            adapter.Fill(records);

            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    list.Add(new EmployeeType(Convert.ToInt32(row["Id"].ToString()), row["Description"].ToString(), Convert.ToBoolean(row["IsActive"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// Get only the active EmployeeType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetActiveEmployeeType()
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetActiveEmployeeType");
            adapter.Fill(records);

            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    list.Add(new EmployeeType(Convert.ToInt32(row["Id"].ToString()), row["Description"].ToString(), Convert.ToBoolean(row["IsActive"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// Insertion of EmployeeType.
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="user"></param>
        public static void InsertEmployeeType(EmployeeType employeeType, User user)
        {
            ArrayList list = new ArrayList();
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_InsertEmployeeType");
            SqlParameter parameter = new SqlParameter("@Id", System.Data.SqlDbType.Int, 16);
            parameter.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(parameter);
            command.Parameters.Add(new SqlParameter("@Description", employeeType.Description));
            command.Parameters.Add(new SqlParameter("@UserId", user.Id));
            command.ExecuteNonQuery();
            employeeType.Id = Convert.ToInt32(command.Parameters["@Id"].Value.ToString());
        }

        /// <summary>
        /// Updation of EmployeeType.
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="user"></param>
        public static void UpdateEmployeeType(EmployeeType employeeType, User user)
        {
            ArrayList list = new ArrayList();
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_UpdateEmployeeType");
            command.Parameters.Add(new SqlParameter("@Id", employeeType.Id));
            command.Parameters.Add(new SqlParameter("@Description", employeeType.Description));
            command.Parameters.Add(new SqlParameter("@UserId", user.Id));
            command.Parameters.Add(new SqlParameter("@IsActive", employeeType.IsActive));
            command.ExecuteNonQuery();
        }

        #endregion

        #region Employee Category Methods

        /// <summary>
        /// Get all the EmployeeCategory.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetAllEmployeeCategory()
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetAllEmployeeCategory");
            adapter.Fill(records);

            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    list.Add(new EmployeeCategory(Convert.ToInt32(row["Id"].ToString()), row["Description"].ToString(), Convert.ToBoolean(row["IsActive"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// Get only the active EmployeeCategory.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetActiveEmployeeCategory()
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetActiveEmployeeCategory");
            adapter.Fill(records);

            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    list.Add(new EmployeeCategory(Convert.ToInt32(row["Id"].ToString()), row["Description"].ToString(), Convert.ToBoolean(row["IsActive"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// Insertion of EmployeeCategory.
        /// </summary>
        /// <param name="employeeCategory"></param>
        /// <param name="user"></param>
        public static void InsertEmployeeCategory(EmployeeCategory employeeCategory, User user)
        {
            ArrayList list = new ArrayList();
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_InsertEmployeeCategory");
            SqlParameter parameter = new SqlParameter("@Id", System.Data.SqlDbType.Int, 16);
            parameter.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(parameter);
            command.Parameters.Add(new SqlParameter("@Description", employeeCategory.Description));
            command.Parameters.Add(new SqlParameter("@UserId", user.Id));
            command.ExecuteNonQuery();
            employeeCategory.Id = Convert.ToInt32(command.Parameters["@Id"].Value.ToString());
        }

        /// <summary>
        /// Updation of EmployeeCategory.
        /// </summary>
        /// <param name="employeeCategory"></param>
        /// <param name="user"></param>
        public static void UpdateEmployeeCategory(EmployeeCategory employeeCategory, User user)
        {
            ArrayList list = new ArrayList();
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_UpdateEmployeeCategory");
            command.Parameters.Add(new SqlParameter("@Id", employeeCategory.Id));
            command.Parameters.Add(new SqlParameter("@Description", employeeCategory.Description));
            command.Parameters.Add(new SqlParameter("@UserId", user.Id));
            command.Parameters.Add(new SqlParameter("@IsActive", employeeCategory.IsActive));
            command.ExecuteNonQuery();
        }
        #endregion

        #region Document Type Methods

        /// <summary>
        /// Get all the DocumentType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetAllDocumentType()
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetAllDocumentType");
            adapter.Fill(records);

            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    list.Add(new DocumentType(Convert.ToInt32(row["Id"].ToString()), row["Description"].ToString(), Convert.ToBoolean(row["IsActive"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// Get only the active DocumentType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetActiveDocumentType()
        {
            ArrayList list = new ArrayList();
            DataSet records = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = DataHelper.GetSqlCommandObject("usp_GetActiveDocumentType");
            adapter.Fill(records);

            if (records != null && records.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in records.Tables[0].Rows)
                {
                    list.Add(new DocumentType(Convert.ToInt32(row["Id"].ToString()), row["Description"].ToString(), Convert.ToBoolean(row["IsActive"].ToString()),
                        row["CreatedBy"].ToString(), row["CreatedDate"].ToString(), row["LastUpdatedBy"].ToString(), row["LastUpdatedDate"].ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// Insertion of DocumentType.
        /// </summary>
        /// <param name="documentType"></param>
        /// <param name="user"></param>
        public static void InsertDocumentType(DocumentType documentType, User user)
        {
            ArrayList list = new ArrayList();
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_InsertDocumentType");
            SqlParameter parameter = new SqlParameter("@Id", System.Data.SqlDbType.Int, 16);
            parameter.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(parameter);
            command.Parameters.Add(new SqlParameter("@Description", documentType.Description));
            command.Parameters.Add(new SqlParameter("@UserId", user.Id));
            command.ExecuteNonQuery();
            documentType.Id = Convert.ToInt32(command.Parameters["@Id"].Value.ToString());
        }

        /// <summary>
        /// Updation of DocumentType.
        /// </summary>
        /// <param name="documentType"></param>
        /// <param name="user"></param>
        public static void UpdateDocumentType(DocumentType documentType, User user)
        {
            ArrayList list = new ArrayList();
            SqlCommand command = DataHelper.GetSqlCommandObject("usp_UpdateDocumentType");
            command.Parameters.Add(new SqlParameter("@Id", documentType.Id));
            command.Parameters.Add(new SqlParameter("@Description", documentType.Description));
            command.Parameters.Add(new SqlParameter("@UserId", user.Id));
            command.Parameters.Add(new SqlParameter("@IsActive", documentType.IsActive));
            command.ExecuteNonQuery();
        }
        #endregion
    }
}
