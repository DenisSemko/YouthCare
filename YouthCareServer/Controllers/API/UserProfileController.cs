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

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationContext applicationContext;

        public UserProfileController(IUnitOfWork unitOfWork, ApplicationContext applicationContext)
        {
            this.unitOfWork = unitOfWork;
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
