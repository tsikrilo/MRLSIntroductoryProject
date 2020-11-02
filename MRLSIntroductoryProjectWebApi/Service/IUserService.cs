using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLRSIntroductoryWebApi.Service
{
    public interface IUserService
    {
        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <returns></returns>
        Task<ActionResult<IEnumerable<User>>> GetUserList();

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The created user</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        Task<ActionResult<User>> CreateUser(User user);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The user which has the specified id</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">userId</exception>
        Task<ActionResult<User>> FetchUserByID(int userId);

        /// <summary>
        /// Updates the user's data with the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userDTO">userDTO</param> TODO xml param names are case sensitive
        /// <returns>The updated user.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        /// <exception cref="System.ArgumentNullException">user</exception>
        /// <exception cref="System.NullReferenceException">user modified</exception>
        Task<ActionResult<User>> EditUser(int id, UserDTO userDto);

        /// <summary>
        /// Disable the user with the specified id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted user</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">id</exception>
        Task<ActionResult<User>> DisableUser(int id);

    }
}
