using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CIL.DTOs;
using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Concrete
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly IMapper mapper;
        public MessageRepository(ApplicationContext myDbContext, IMapper mapper) : base(myDbContext)
        {
            this.mapper = mapper;
        }

        public void AddMessage(Message message)
        {
            myDbContext.Message.Add(message);
        }
        public void DeleteMessage(Message message)
        {
            myDbContext.Message.Remove(message);
        }

        public new async Task<Message> GetById(Guid id)
        {
            return await myDbContext.Message
                .Include(s => s.SenderId)
                .Include(r => r.RecepientId)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
        {
            var query = myDbContext.Message
                .OrderByDescending(m => m.MessageSent)
                .AsQueryable();

            query = messageParams.Container switch
            {
                "Inbox" => query.Where(u => u.RecepientId.UserName == messageParams.Username
                    && u.RecepientDeleted == false),
                "Outbox" => query.Where(u => u.SenderId.UserName == messageParams.Username
                    && u.SenderDeleted == false),
                _ => query.Where(u => u.RecepientId.UserName ==
                    messageParams.Username && u.RecepientDeleted == false && u.MessageRead == null)
            };

            var messages = query.ProjectTo<MessageDto>(mapper.ConfigurationProvider);
            return await PagedList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize, messageParams.Username);
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername)
        {
            var messages = await myDbContext.Message
                .Include(u => u.SenderId)
                .Include(u => u.RecepientId)
                .Where(m => m.RecepientId.UserName == currentUsername && m.RecepientDeleted == false
                        && m.SenderId.UserName == recipientUsername
                        || m.RecepientId.UserName == recipientUsername
                        && m.SenderId.UserName == currentUsername && m.SenderDeleted == false
                )
                .OrderBy(m => m.MessageSent)
                .ToListAsync();

            var unreadMessages = messages.Where(m => m.MessageRead == null
                && m.RecepientId.UserName == currentUsername).ToList();

            if (unreadMessages.Any())
            {
                foreach (var message in unreadMessages)
                {
                    message.MessageRead = DateTime.Now;
                }

                await myDbContext.SaveChangesAsync();
            }

            return mapper.Map<IEnumerable<MessageDto>>(messages);
        }
    }
}
