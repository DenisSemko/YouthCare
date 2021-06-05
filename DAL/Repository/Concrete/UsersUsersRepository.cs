using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Concrete
{
    public class UsersUsersRepository : BaseRepository<UsersUsers>, IUsersUsersRepository
    {
        public UsersUsersRepository(ApplicationContext myDbContext) : base(myDbContext) { }

        public async Task<IEnumerable<User>> GetBySectionUserType(Guid id, string type)
        {
            var result = await myDbContext.Users.Where(o => o.BelongSection.Id == id).Where(o => o.UserType == type).Include(o => o.BelongSection).ToListAsync();
            return result;
        }
    }
}
