using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IUsersUsersService
    {
        public Task<IEnumerable<UsersUsers>> Get();
        public Task<IEnumerable<User>> GetBySectionUserType(Guid id, string type);
        public Task<UsersUsers> Add(UsersUsers item);
    }
}
