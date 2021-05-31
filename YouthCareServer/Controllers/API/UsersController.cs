using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.DTOs;
using CIL.Models;
using DAL.Repository.Abstract;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using DAL;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        ApplicationContext myDbContext;
        private readonly IMapper mapper;

        public UsersController(IUnitOfWork unitOfWork, ApplicationContext myDbContext, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await unitOfWork.UserRepository.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            try
            {
                //var result = await userRepository.GetById(id);
                var result = await myDbContext.Users.Where(o => o.Id == id).Include(o => o.BelongSection).FirstOrDefaultAsync();
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
        public async Task<ActionResult<User>> Add(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                var result = await unitOfWork.UserRepository.Add(user);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut]
        public async Task<ActionResult<User>> Update(UserDto userDto)
        {
            try
            {
                var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(userDto.Username);
                mapper.Map(userDto, user);
                await unitOfWork.UserRepository.Update(user);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<User>> DeleteById(Guid id)
        {
            try
            {
                var result = await unitOfWork.UserRepository.DeleteById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
