using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLRSIntroductoryWebApi.Models;

namespace MRLSIntroductoryProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly UserContext _context;

        public UserTypesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserType()
        {
            return await _context.UserType.ToListAsync();
        }
    }
}
