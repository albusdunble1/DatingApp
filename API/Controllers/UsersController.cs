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
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        // IEnumerable is one way to return lists (uses simple iteration over a collection of a specific type)
        // List is another way with more features such as search, sort etc
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users = this.context.Users.ToListAsync();

            return await users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){

            var user = this.context.Users.FindAsync(id);
            return await user;

            // or
            // return this.context.Users.Find(id);
        }

    }
}