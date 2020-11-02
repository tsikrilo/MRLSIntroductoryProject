using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TODO cleanup imports
// TODO fix all namespaces
namespace MLRSIntroductoryWebApi.DTO
{
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the birthdate.
        /// </summary>
        /// <value>
        /// The birthdate.
        /// </value>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Gets or sets the user type identifier.
        /// </summary>
        /// <value>
        /// The user type identifier.
        /// </value>
        public int UserTypeId { get; set; }

        /// <summary>
        /// Gets or sets the user title identifier.
        /// </summary>
        /// <value>
        /// The user title identifier.
        /// </value>
        public int UserTitleId { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
