using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// This represents EmployeeType entity.
    /// </summary>
    public class EmployeeType: ReferenceDataActive
    {
        /// <summary>
        /// Default constructor of EmployeeType class.
        /// </summary>
        public EmployeeType() : base()
        {
        }

        /// <summary>
        /// Parameterised constructor of EmployeeType class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="isActive"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <param name="lastUpdatedDate"></param>
        public EmployeeType(int id, string description, bool isActive, string createdBy, string createdDate,
            string lastUpdatedBy, string lastUpdatedDate) 
            :base(id, description, isActive, createdBy, createdDate,lastUpdatedBy,lastUpdatedDate)
        {
        }

        /// <summary>
        /// Parameterised constructor of EmployeeType class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public EmployeeType(int id, string description) : base(id, description)
        {
        }
    }
}
