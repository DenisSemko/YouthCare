using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork unitOfWork;

        public MessageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Message>> Get()
        {
            return await unitOfWork.MessageRepository.Get();
        }

        public async Task<Message> GetById(Guid id)
        {
            var result = await unitOfWork.MessageRepository.GetById(id);
            return result;
        }

        public async Task<Message> Add(Message message)
        {
            var result = await unitOfWork.MessageRepository.Add(message);
            return result;
        }

        public async Task<Message> Update(Message message)
        {
            var result = await unitOfWork.MessageRepository.Update(message);
            return result;
        }

        public async Task<Message> DeleteById(Guid id)
        {
            var result = await unitOfWork.MessageRepository.DeleteById(id);
            return result;
        }
    }
}
