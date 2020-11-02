using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLRSIntroductoryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRLSIntroductoryProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly UserContext _context;

        public UserTypesController(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/UserTypes
        /// <summary>
        /// Gets the type of the user.
        /// </summary>
        /// <returns>A list of user types</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserType()
        {
            return await _context.UserType.ToListAsync();
        }
    }
}
