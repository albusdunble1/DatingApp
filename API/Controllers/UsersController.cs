using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // These attributes and methods will be inherited from the BaseApiController, so it's not needed
    // [ApiController]
    // [Route("api/[controller]")]
    [Authorize]
    public class UsersController : BaseApiController
    {
        public IUserRepository userRepo { get; }
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepo = userRepo;

        }

        [HttpGet]
        // [AllowAnonymous]
        // IEnumerable is one way to return lists (uses simple iteration over a collection of a specific type)
        // List is another way with more features such as search, sort etc
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // previous less efficient mapping that unnecessarily queries all properties in AppUser that's not included in MemberDto including passowrdhash and salt
            // var users = await this.userRepo.GetUsersAsync();

            // var usersToReturn = this.mapper.Map<IEnumerable<MemberDto>>(users);

            // return Ok(usersToReturn);

            // more efficient mapping that does not unnecessarily queries all properties 
            var users = await this.userRepo.GetMembersAsync();

            return Ok(users);
        }

        // [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {

            return await this.userRepo.GetMemberByUsernameAsync(username);

            // or
            // return this.context.Users.Find(id);
        }

    }
}