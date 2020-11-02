using MLRSIntroductoryWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLRSIntroductoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTitlesController : ControllerBase
    {
        private readonly UserContext _context;

        // TODO no reason for anything other than GET methods
        public UserTitlesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTitle>>> GetUserTitle()
        {
            return await _context.UserTitle.ToListAsync();
        }
    }
}
