using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccess;

namespace BusinessLogic
{
    public class MasterLogic
    {
        #region Employee Type Methods

        /// <summary>
        /// This method save the EmployeeType.
        /// </summary>
        /// <param name="employeeType"></param>
        /// <param name="user"></param>
        public static void SaveEmployeeType(EmployeeType employeeType, User user)
        {
            if (employeeType.Id < 0 && employeeType.IsActive)
            {
                MasterData.InsertEmployeeType(employeeType, user);
            }
            else if (employeeType.IsDirty && employeeType.Id > 0)
            {
                MasterData.UpdateEmployeeType(employeeType, user);
            }
        }

        /// <summary>
        /// This method keep the list of GetAllEmployeeType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetAllEmployeeType()
        {
            return MasterData.GetAllEmployeeType();
        }

        /// <summary>
        /// This method keep the list of GetActiveEmployeeType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetActiveEmployeeType()
        {
            return MasterData.GetActiveEmployeeType();
        }
        #endregion

        #region Employee Category Methods

        /// <summary>
        /// This method save the EmployeeCategory.
        /// </summary>
        /// <param name="employeeCategory"></param>
        /// <param name="user"></param>
        public static void SaveEmployeeCategory(EmployeeCategory employeeCategory, User user)
        {
            if (employeeCategory.Id < 0 && employeeCategory.IsActive)
            {
                MasterData.InsertEmployeeCategory(employeeCategory, user);
            }
            else if (employeeCategory.IsDirty && employeeCategory.Id > 0)
            {
                MasterData.UpdateEmployeeCategory(employeeCategory, user);
            }
        }

        /// <summary>
        /// This method keep the list of GetAllEmployeeCategory.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetAllEmployeeCategory()
        {
            return MasterData.GetAllEmployeeCategory();
        }

        /// <summary>
        /// This method keep the list of GetActiveEmployeeCategory.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetActiveEmployeeCategory()
        {
            return MasterData.GetActiveEmployeeCategory();
        }
        #endregion

        #region Document Type Methods

        /// <summary>
        /// This method save the DocumentType.
        /// </summary>
        /// <param name="documentType"></param>
        /// <param name="user"></param>
        public static void SaveDocumentType(DocumentType documentType, User user)
        {
            if (documentType.Id < 0 && documentType.IsActive)
            {
                MasterData.InsertDocumentType(documentType, user);
            }
            else if (documentType.IsDirty && documentType.Id > 0)
            {
                MasterData.UpdateDocumentType(documentType, user);
            }
        }

        /// <summary>
        /// This method keep the list of GetAllDocumentType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetAllDocumentType()
        {
            return MasterData.GetAllDocumentType();
        }

        /// <summary>
        /// This method keep the list of GetActiveDocumentType.
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetActiveDocumentType()
        {
            return MasterData.GetActiveDocumentType();
        }
        #endregion
    }
}
