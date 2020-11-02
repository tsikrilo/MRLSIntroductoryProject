using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLRSIntroductoryWebApi.Models;

namespace MRLSIntroductoryProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTitlesController : ControllerBase
    {
        private readonly UserContext _context;

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
