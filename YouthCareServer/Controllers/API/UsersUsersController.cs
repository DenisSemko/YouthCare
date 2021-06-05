using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;
using DAL;
using BLL.Services.Abstract;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersUsersController : ControllerBase
    {
        private readonly IUsersUsersService usersUsersService;

        public UsersUsersController(IUsersUsersService usersUsersService)
        {
            this.usersUsersService = usersUsersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersUsers>>> Get()
        {
            return Ok(await usersUsersService.Get());
        }

        [HttpGet("{id:Guid}/{type}")]
        public async Task<ActionResult<IEnumerable<User>>> GetBySectionUserType(Guid id, string type)
        {
            try
            {
                var result = await usersUsersService.GetBySectionUserType(id, type);
                if (result == null) return NotFound();

                return result.ToList();
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

                var result = await usersUsersService.Add(users);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
