using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// This represents User entity.
    /// </summary>
    public class User
    {
        #region Private variables
        private int id = -1;
        private string userName = string.Empty;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string password = string.Empty;
        private bool isActive = true;
        private bool isDirty = false;
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
        /// Get or set the Id of User.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the UserName of User.
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the FirstName of User.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the LastName of User.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the Password of User.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; IsDirty = true; }
        }

        /// <summary>
        /// Get or set the value of IsActive.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; IsDirty = true; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor of User class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Overloaded constructor of User class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="isActive"></param>
        public User(int id, string userName, string firstName, string lastName, string password, bool isActive)
        {
            this.id = id;
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.isActive = isActive;
        }
        #endregion
    }
}
