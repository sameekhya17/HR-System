using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// This represents DocumentType entity.
    /// </summary>
    public class DocumentType : ReferenceDataActive
    {
        /// <summary>
        /// Default constructor of DocumentType class.
        /// </summary>
        public DocumentType() : base()
        {
        }

        /// <summary>
        /// Parameterised constructor of DocumentType class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public DocumentType(int id, string description)
            : base(id, description)
        {

        }

        /// <summary>
        /// Parameterised constructor of DocumentType class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="isActive"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <param name="lastUpdatedDate"></param>
        public DocumentType(int id, string description, bool isActive, string createdBy, string createdDate,
            string lastUpdatedBy, string lastUpdatedDate)
            : base(id, description, isActive, createdBy, createdDate, lastUpdatedBy, lastUpdatedDate)
        {

        }
    }
}
