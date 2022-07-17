using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// This represents EmployeeCategory entity.
    /// </summary>
    public class EmployeeCategory : ReferenceDataActive
    {
        /// <summary>
        /// Default constructor of EmployeeCategory class.
        /// </summary>
        public EmployeeCategory() : base()
        {
        }

        /// <summary>
        /// Parameterised constructor of EmployeeCategory class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="isActive"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <param name="lastUpdatedDate"></param>
        public EmployeeCategory(int id, string description, bool isActive, string createdBy, string createdDate,
            string lastUpdatedBy, string lastUpdatedDate)
            : base(id, description, isActive, createdBy, createdDate, lastUpdatedBy, lastUpdatedDate)
        {

        }

        /// <summary>
        /// Parameterised constructor of EmployeeCategory class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public EmployeeCategory(int id, string description) : base(id, description)
        {

        }
    }
}


    


    