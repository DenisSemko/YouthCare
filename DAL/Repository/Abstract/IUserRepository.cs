using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;

namespace DAL.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetUserByUsernameAsync(string username);
    }
}
