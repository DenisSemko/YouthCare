using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class UsersUsersService : IUsersUsersService
    {
        private readonly IUnitOfWork unitOfWork;

        public UsersUsersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UsersUsers>> Get()
        {
            return await unitOfWork.UsersUsersRepository.Get();
        }
        public async Task<IEnumerable<User>> GetBySectionUserType(Guid id, string type)
        {
            var result = await unitOfWork.UsersUsersRepository.GetBySectionUserType(id, type);
            return result;
        }
        public async Task<UsersUsers> Add(UsersUsers user)
        {
            var result = await unitOfWork.UsersUsersRepository.Add(user);
            return result;
        }
    }
}
