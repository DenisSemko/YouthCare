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
        private readonly IMessageRepository messageRepository;

        public MessageService(IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> Get()
        {
            return await messageRepository.Get();
        }

        public async Task<Message> GetById(Guid id)
        {
            var result = await messageRepository.GetById(id);
            return result;
        }

        public async Task<Message> Add(Message message)
        {
            var result = await messageRepository.Add(message);
            return result;
        }

        public async Task<Message> Update(Message message)
        {
            var result = await messageRepository.Update(message);
            return result;
        }

        public async Task<Message> DeleteById(Guid id)
        {
            var result = await messageRepository.DeleteById(id);
            return result;
        }
    }
}
