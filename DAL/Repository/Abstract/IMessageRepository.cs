using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.DTOs;
using CIL.Models;

namespace DAL.Repository.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername);
        new Task<Message> GetById(Guid id);
    }
}
