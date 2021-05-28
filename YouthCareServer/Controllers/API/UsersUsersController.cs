using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Models;
using YouthCareServer.Repository.Abstract;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersUsersController : ControllerBase
    {
        private readonly ApplicationContext myDbContext;
        private readonly IUsersUsersRepository userRepository;

        public UsersUsersController(ApplicationContext myDbContext, IUsersUsersRepository userRepository)
        {
            this.myDbContext = myDbContext;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersUsers>>> Get()
        {
            return Ok(await userRepository.Get());
        }

        [HttpGet("{id:Guid}/{type}")]
        public async Task<ActionResult<IEnumerable<User>>> GetBySectionUserType(Guid id, string type)
        {
            try
            {
                var result = await myDbContext.Users.Where(o => o.BelongSection.Id == id).Where(o => o.UserType == type).Include(o => o.BelongSection).ToListAsync();
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsersUsers>> Add(UsersUsers users)
        {
            try
            {
                if (users == null)
                {
                    return BadRequest();
                }

                var result = await userRepository.Add(users);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
