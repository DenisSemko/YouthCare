using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Models;
using YouthCareServer.Repository.Abstract;

namespace YouthCareServer.Repository.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext myDbContext) : base(myDbContext) {}

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await myDbContext.Users
                .SingleOrDefaultAsync(x => x.UserName == username);
        }
    }
}
