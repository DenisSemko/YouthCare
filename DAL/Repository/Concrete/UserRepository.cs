using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext myDbContext) : base(myDbContext) {}

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await myDbContext.Users
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public new async Task<User> GetById(Guid id)
        {
            var result = await myDbContext.Users.Where(o => o.Id == id).Include(o => o.BelongSection).FirstOrDefaultAsync();
            return result;
        }
    }
}
