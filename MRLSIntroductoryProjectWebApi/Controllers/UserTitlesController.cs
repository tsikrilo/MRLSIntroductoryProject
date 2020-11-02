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
    public class UserTitlesController : ControllerBase
    {
        private readonly UserContext _context;

        public UserTitlesController(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/UserTitles
        /// <summary>
        /// Gets the user title.
        /// </summary>
        /// <returns>A list of user titles</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTitle>>> GetUserTitle()
        {
            return await _context.UserTitle.ToListAsync();
        }
    }
}
