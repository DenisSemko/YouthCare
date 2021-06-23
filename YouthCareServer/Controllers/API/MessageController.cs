using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using CIL.DTOs;
using AutoMapper;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public MessageController(IMessageService messageService, IMessageRepository messageRepository, IUserRepository userRepository, IMapper mapper)
        {
            this.messageService = messageService;
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesForUser([FromQuery]
            MessageParams messageParams)
        {

            var messages = await messageRepository.GetMessagesForUser(messageParams);

            Response.AddPaginationHeader(messages.CurrentPage, messages.PageSize,
                messages.TotalCount, messages.TotalPages, messages.Username);

            return messages;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Message>> GetById(Guid id)
        {
            try
            {
                var result = await messageService.GetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{currentUsername}/{username}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageThread(string currentUsername, string username)
        {
            return Ok(await messageRepository.GetMessageThread(currentUsername, username));
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> Add(CreateMessageDto createMessageDto)
        {
            try
            {
                var username = createMessageDto.SenderUsername;
                if (username == createMessageDto.RecepientUsername.ToLower())
                {
                    return BadRequest("You cannot send messages to yourself!");
                }

                var sender = await userRepository.GetUserByUsernameAsync(username);
                var recepient = await userRepository.GetUserByUsernameAsync(createMessageDto.RecepientUsername);

                if (recepient == null) return NotFound();

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
                    return BadRequest("You cannot send an empty message");
                }

                messageRepository.Save();
                return Ok(mapper.Map<MessageDto>(message));

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut]
        public async Task<ActionResult<Message>> Update(Message message)
        {
            var result = await messageService.Update(message);
            return result;
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Message>> DeleteById(Guid id)
        {
            try
            {
                var result = await messageService.DeleteById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting the message record");
            }
        }
    }
}
