using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// This represents an Employee Entity.
    /// </summary>
    public class Employee
    {
        #region Private variables
        private int id = -1;
        private string firstName = string.Empty;
        private string middleName = string.Empty;
        private string lastName = string.Empty;
        private EmployeeCategory category;
        private EmployeeType employeeType;
        private DateTime dateOfJoining;
        private DateTime dateOfBirth;
        private ArrayList employeeDocuments;
        private bool isDirty = false;
        private string createdBy = string.Empty;
        private string createdDate = string.Empty;
        private string lastUpdatedBy = string.Empty;
        private string lastUpdatedDate = string.Empty;
        private bool isActive = true;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set the value of IsDirty.
        /// </summary>
        public bool IsDirty
        {
            get { return isDirty; }
            set { isDirty = value; }
        }

        /// <summary>
        /// Get or set the Id of employee.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Get the Fullname of Employee.
        /// </summary>
        public string FullName
        {
            get { return (firstName + " " + middleName).Trim() + " " + lastName; }
        }

        /// <summary>
        /// Get or set the arraylist of EmployeeDocuments.
        /// </summary>
        public ArrayList EmployeeDocuments
        {
            get { return employeeDocuments; }
            set { employeeDocuments = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the Firstname of Employee.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the Middlename of Employee.
        /// </summary>
        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the Lastname of Employee.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the Category of EmployeeCategory.
        /// </summary>
        public EmployeeCategory Category
        {
            get { return category; }
            set { category = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the EmployeeType of EmployeeType.
        /// </summary>
        public EmployeeType EmployeeType
        {
            get { return employeeType; }
            set { employeeType = value; IsDirty = true; }
        }

        /// <summary>
        /// Get the Categorytext of EmployeeCategory.
        /// </summary>
        public string CategoryText
        {
            get { return category.Description; }
        }

        /// <summary>
        /// Get the Employeetypetext of EmployeeType.
        /// </summary>
        public string EmployeeTypeText
        {
            get { return employeeType.Description; }
        }

        /// <summary>
        /// Get or set the DateOfBirth of Employee.
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the DateOfJoining of Employee.
        /// </summary>
        public DateTime DateOfJoining
        {
            get { return dateOfJoining; }
            set { dateOfJoining = value; IsDirty = true; }
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
        /// Get the IsActiveText of Employee.
        /// </summary>
        public string IsActiveText
        {
            get
            {
                return isActive == true ? "Yes" : "No";
            }
        }

        /// <summary>
        /// Get the CreatedBy of employee.
        /// </summary>
        public string CreatedBy
        {
            get { return createdBy; }
        }

        /// <summary>
        /// Get the CreatedDate of employee.
        /// </summary>
        public string CreatedDate
        {
            get { return createdDate; }
        }

        /// <summary>
        /// Get the LastUpdatedBy of Employee.
        /// </summary>
        public string LastUpdatedBy
        {
            get { return lastUpdatedBy; }
        }

        /// <summary>
        /// Get the LastUpdatedDate of Employee.
        /// </summary>
        public string LastUpdatedDate
        {
            get { return lastUpdatedDate; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor of Employee class.
        /// </summary>
        public Employee()
        {
            employeeDocuments = new ArrayList();
        }

        /// <summary>
        /// Overloaded constructor of Employee class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="category"></param>
        /// <param name="employeeType"></param>
        /// <param name="dateOfJoining"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <param name="lastUpdatedDate"></param>
        /// <param name="isActive"></param>
        public Employee(int id, string firstName, string middleName, string lastName, EmployeeCategory category, EmployeeType employeeType,
            DateTime dateOfJoining, DateTime dateOfBirth, string createdBy, string createdDate, string lastUpdatedBy, string lastUpdatedDate, bool isActive)
        {
            this.id = id;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.category = category;
            this.employeeType = employeeType;
            this.dateOfJoining = dateOfJoining;
            this.dateOfBirth = dateOfBirth;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;
            this.isActive = isActive;
            employeeDocuments = new ArrayList();
        }

        /// <summary>
        /// Overloaded constructor of Employee class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="category"></param>
        /// <param name="employeeType"></param>
        /// <param name="dateOfJoining"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="createdBy"></param>
        /// <param name="createdDate"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <param name="lastUpdatedDate"></param>
        /// <param name="isActive"></param>
        /// <param name="employeeDocuments"></param>
        public Employee(int id, string firstName, string middleName, string lastName, EmployeeCategory category, EmployeeType employeeType,
            DateTime dateOfJoining, DateTime dateOfBirth, string createdBy, string createdDate, string lastUpdatedBy, string lastUpdatedDate, bool isActive, ArrayList employeeDocuments)
        {
            this.id = id;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.category = category;
            this.employeeType = employeeType;
            this.dateOfJoining = dateOfJoining;
            this.dateOfBirth = dateOfBirth;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;
            this.isActive = isActive;
            this.employeeDocuments = employeeDocuments;
        }
        #endregion
    }
}
