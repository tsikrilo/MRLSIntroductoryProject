using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;

namespace MRLSIntroductoryProjectWebApi.Data
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>The list of users</returns>
        Task<ActionResult<IEnumerable<User>>> GetUsers();

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The user which has the specified id</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">userId</exception>
        Task<ActionResult<User>> GetUserByID(int userId);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The created user</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        Task<ActionResult<User>> InsertUser(User user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted user</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        Task<ActionResult<User>> DeleteUser(int userId);

        /// <summary>
        /// Updates the user's data with the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userDto">The updated user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        /// <exception cref="System.ArgumentNullException">user</exception>
        /// <exception cref="System.NullReferenceException">user modified</exception>
        Task<ActionResult<User>> UpdateUser(int i, UserDTO userDto);
    }
}
