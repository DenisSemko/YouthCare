using AutoMapper;
using BLL.Services.Abstract;
using CIL.DTOs;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await unitOfWork.UserRepository.Get();
        }

        public async Task<User> GetById(Guid id)
        {
            var result = await unitOfWork.UserRepository.GetById(id);
            return result;
        }

        public async Task<User> Add(User user)
        {
            var result = await unitOfWork.UserRepository.Add(user);
            return result;
        }

        public async Task<User> Update(User user)
        {
            var result = await unitOfWork.UserRepository.Update(user);
            return result;
        }
        public async Task<User> Update(UserDto userDto)
        {
            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(userDto.Username);
            mapper.Map(userDto, user);
            await unitOfWork.UserRepository.Update(user);
            return user;
        }

        public async Task<User> DeleteById(Guid id)
        {
            var result = await unitOfWork.UserRepository.DeleteById(id);
            return result;
        }
    }
}
