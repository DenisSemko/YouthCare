using AutoMapper;
using CIL.DTOs;
using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class MessageHub : Hub
    {
        private readonly IMapper mapper;
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        public MessageHub(IMapper mapper, IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }

        public async Task NewMessage(CreateMessageDto createMessageDto)
        {
            try
            {
                var username = createMessageDto.SenderUsername;
                if (username == createMessageDto.RecepientUsername.ToLower())
                {
                    throw new HubException("You cannot send messages to yourself");
                }

                var sender = await userRepository.GetUserByUsernameAsync(username);
                var recepient = await userRepository.GetUserByUsernameAsync(createMessageDto.RecepientUsername);

                if (recepient == null) throw new HubException("Not found user");

                var message = new Message
                {
                    SenderId = sender,
                    RecepientId = recepient,
                    SenderUsername = sender.UserName,
                    RecepientUsername = recepient.UserName,
                    Content = createMessageDto.Content.Trim()
                };

                messageRepository.AddMessage(message);

                if (string.IsNullOrWhiteSpace(message.Content))
                {
                    throw new HubException("You cannot send an empty message");
                }

                messageRepository.Save();
                await Clients.All.SendAsync("MessageReceived", mapper.Map<MessageDto>(message));

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
