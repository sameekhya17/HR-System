using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// This represents ReferenceDataActive entity.
    /// </summary>
    public class ReferenceDataActive
    {
        #region Private variables
        private int id = -1;
        private string description = string.Empty;
        private bool isActive = true;
        private bool isDirty = false;
        private string createdBy = string.Empty;
        private string createdDate = string.Empty;
        private string lastUpdatedBy = string.Empty;
        private string lastUpdatedDate = string.Empty;
        #endregion

        #region Properties

        /// <summary>
        /// Get the IsActiveText of ReferenceDataActive.
        /// </summary>
        public string IsActiveText
        {
            get
            {
                return isActive == true ? "Yes" : "No";
            }
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
        /// Get or set the Id of ReferenceDataActive.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Get or set the Description of ReferenceDataActive.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; IsDirty = true; }
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
        /// Get the CreatedBy of ReferenceDataActive.
        /// </summary>
        public string CreatedBy
        {
            get { return createdBy; }
        }

        /// <summary>
        /// Get the CreatedDate of ReferenceDataActive.
        /// </summary>
        public string CreatedDate
        {
            get { return createdDate; }
        }

        /// <summary>
        /// Get the LastUpdatedBy of ReferenceDataActive.
        /// </summary>
        public string LastUpdatedBy
        {
            get { return lastUpdatedBy; }
        }

        /// <summary>
        /// Get the LastUpdatedDate of ReferenceDataActive.
        /// </summary>
        public string LastUpdatedDate
        {
            get { return lastUpdatedDate; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor of ReferenceDataActive class.
        /// </summary>
        public ReferenceDataActive()
        {
        }

        /// <summary>
        /// Overloaded constructor of ReferenceDataActive class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="isActive"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <param name="lastUpdatedDate"></param>
        public ReferenceDataActive(int id, string description, bool isActive, string createdBy, string createdDate,
            string lastUpdatedBy, string lastUpdatedDate)
        {
            this.id = id;
            this.description = description;
            this.isActive = isActive;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;
        }

        /// <summary>
        /// Overloaded constructor of ReferenceDataActive class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public ReferenceDataActive(int id, string description)
        {
            this.id = id;
            this.description = description;
        }
        #endregion
    }
}
