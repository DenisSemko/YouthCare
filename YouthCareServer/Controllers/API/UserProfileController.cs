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
    public class UserProfileController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ApplicationContext applicationContext;

        public UserProfileController(IUserRepository userRepository, ApplicationContext applicationContext)
        {
            this.userRepository = userRepository;
            this.applicationContext = applicationContext;
        }

        [HttpGet]
        public async Task<Object> Get()
        {
            var userId = User.Claims.First(c => c.Type == "id").Value;
            Guid userIdObj = Guid.Parse(userId);
            var result = await applicationContext.Users.Where(o => o.Id == userIdObj).Include(o => o.BelongSection).FirstOrDefaultAsync();

            return new
            {
                result.Id,
                result.Name,
                result.MiddleName,
                result.Surname,
                result.UserName,
                result.PasswordHash,
                result.Email,
                result.Address,
                result.PhoneNumber,
                result.BirthDate,
                result.UserType,
                result.ProfilePicture,
                result.BelongSection
            };
        }


    }
}
