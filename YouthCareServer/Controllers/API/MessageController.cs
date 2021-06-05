using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using Microsoft.AspNetCore.Http;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> Get()
        {
            return Ok(await messageService.Get());
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

        [HttpPost]
        public async Task<ActionResult<Message>> Add(Message message)
        {
            try
            {
                if (message == null)
                {
                    return BadRequest();
                }

                var result = await messageService.Add(message);
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the new message record");
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
