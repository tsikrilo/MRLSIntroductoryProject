using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;
using MLRSIntroductoryWebApi.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRLSIntroductoryProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        public UsersController(IUserService userService, ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: api/Users
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>A list of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userService.GetUserList();
        }

        // GET: api/Users/5
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user associated with the parameter id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                return await _userService.FetchUserByID(id);
            }
            catch (Exception)
            {
                _logger.LogError("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }

        // PUT: api/Users/5
        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userDto">The user dto.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser([FromRoute] int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                return await _userService.EditUser(id, userDTO);
            }
            catch (Exception)
            {
                _logger.LogError("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }

        // POST: api/Users
        /// <summary>
        /// Posts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The user which is created</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                return await _userService.CreateUser(user);
            }
            catch (Exception)
            {
                _logger.LogError("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }

        // DELETE: api/Users/5
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                return await _userService.DisableUser(id);
            }
            catch (Exception)
            {
                _logger.LogError("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }
    }
}
