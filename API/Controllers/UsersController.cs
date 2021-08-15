using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // in order to get to this controller, especify the route
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        // endpoint to all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() // an Ienumerable is a simpler form of list
        {
            return await _context.Users.ToListAsync();  // have to use async method for await
        }

        // endpoint to specific user in databse
        // api/users/3
        [HttpGet("{id}")]
        public async Task <ActionResult<AppUser>> GetUsers(int id) // an Ienumerable is a simpler form of list
        {
            return await _context.Users.FindAsync(id); // have to use async method for await
        }



    }
}