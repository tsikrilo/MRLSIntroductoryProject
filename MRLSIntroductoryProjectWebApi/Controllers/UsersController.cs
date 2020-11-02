using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MLRSIntroductoryWebApi.DTO;
using MLRSIntroductoryWebApi.Models;
using MLRSIntroductoryWebApi.Service;

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
        // TODO xml doc in public controller methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userService.GetUserList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // TODO no need for such checks in controller
            if (id <= 0)
            {
                _logger.LogInformation("Argument userId is less or equal to zero.");
                return BadRequest();
            }

            try
            {
                return await _userService.FetchUserByID(id);
            }
            catch (Exception)
            {
                // TODO exceptions should be error log
                _logger.LogInformation("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser([FromRoute] int id, [FromBody] UserDTO userDTO)
        {
            if (id <= 0)
            {
                _logger.LogInformation("Argument id is less or equal to zero.");
                return BadRequest();
            }

            if (userDTO is null)
            {
                _logger.LogInformation("Argument userDTO is null.");
                return BadRequest();
            }

            try
            {
                return await _userService.EditUser(id, userDTO);
            }
            catch (Exception)
            {
                _logger.LogInformation("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (user is null)
            {
                _logger.LogInformation("Argument user is null.");
                return BadRequest();
            }

            try
            {
                return await _userService.CreateUser(user);
            }
            catch (Exception)
            {
                _logger.LogInformation("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (id <= 0)
            {
                _logger.LogInformation("Argument id is less or equal to zero.");
                return BadRequest();
            }

            try
            {
                return await _userService.DisableUser(id);
            }
            catch (Exception)
            {
                _logger.LogInformation("Internal Server Error");
                return new StatusCodeResult(500);
            }
        }
    }
}
