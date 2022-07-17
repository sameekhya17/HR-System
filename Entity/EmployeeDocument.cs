using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// This represents EmployeeDocument entity.
    /// </summary>
    public class EmployeeDocument
    {
        #region Private variables
        private int id = -1;
        private DocumentType documentType;
        private string fileName = string.Empty;
        private bool isDirty = false;
        private string createdBy = string.Empty;
        private string createdDate = string.Empty;
        private string lastUpdatedBy = string.Empty;
        private string lastUpdatedDate = string.Empty;
        private bool isActive = true;
        private HttpPostedFile postedFile;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the PostedFile of HttpPostedFile.
        /// </summary>
        public HttpPostedFile PostedFile
        {
            get { return postedFile; }
            set { postedFile = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the FileName of EmployeeDocument.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the DocumentType of DocumentType.
        /// </summary>
        public DocumentType DocumentType
        {
            get { return documentType; }
            set { documentType = value; IsDirty = true; }
        }

        /// <summary>
        /// Get the DocumentTypeText of DocumentType.
        /// </summary>
        public string DocumentTypeText
        {
            get { return documentType.Description; }
        }

        /// <summary>
        /// Get or set the value of IsActive.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; IsDirty = true; }
        }

        /// <summary>
        /// Get the IsActiveText of EmployeeDocument.
        /// </summary>
        public string IsActiveText
        {
            get
            {
                return isActive == true ? "Yes" : "No";
            }
        }

        /// <summary>
        /// Get the CreatedBy of EmployeeDocument.
        /// </summary>
        public string CreatedBy
        {
            get { return createdBy; }
        }

        /// <summary>
        /// Get the CreatedDate of EmployeeDocument.
        /// </summary>
        public string CreatedDate
        {
            get { return createdDate; }
        }

        /// <summary>
        /// Get the LastUpdatedBy of EmployeeDocument.
        /// </summary>
        public string LastUpdatedBy
        {
            get { return lastUpdatedBy; }
        }

        /// <summary>
        /// Get the LastUpdatedDate of EmployeeDocument.
        /// </summary>
        public string LastUpdatedDate
        {
            get { return lastUpdatedDate; }
        }

        /// <summary>
        /// Get or set the value of IsDirty.
        /// </summary>
        public bool IsDirty
        {
            get { return isDirty; }
            set { isDirty = value; }
        }

        /// <summary>
        /// Get or set the Id of EmployeeDocument.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor of EmployeeDocument class.
        /// </summary>
        public EmployeeDocument()
        {
        }

        /// <summary>
        /// Overloaded constructor of EmployeeDocument class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileName"></param>
        /// <param name="documentType"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <param name="lastUpdatedDate"></param>
        /// <param name="isActive"></param>
        public EmployeeDocument(int id, string fileName, DocumentType documentType, string createdBy, string createdDate,
            string lastUpdatedBy, string lastUpdatedDate, bool isActive)
        {
            this.id = id;
            this.fileName = fileName;
            this.documentType = documentType;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;
            this.isActive = isActive;
        }

        /// <summary>
        /// Overloaded constructor of EmployeeDocument class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileName"></param>
        /// <param name="documentType"></param>
        /// <param name="file"></param>
        /// <param name="isActive"></param>
        public EmployeeDocument(int id, string fileName, DocumentType documentType, HttpPostedFile file, bool isActive)
        {
            this.id = id;
            this.fileName = fileName;
            this.documentType = documentType;
            this.postedFile = file;
            this.isActive = isActive;
        }
        #endregion
    }
}


