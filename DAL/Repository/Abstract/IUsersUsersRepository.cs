using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;

namespace DAL.Repository.Abstract
{
    public interface IUsersUsersRepository : IRepository<UsersUsers>
    {
        public Task<IEnumerable<User>> GetBySectionUserType(Guid id, string type);
    }
}
