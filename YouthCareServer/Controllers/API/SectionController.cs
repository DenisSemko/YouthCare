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
    public class SectionController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SectionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> Get()
        {
            return Ok(await unitOfWork.SectionRepository.Get());
        }

        [HttpPost]
        public async Task<ActionResult<Section>> Add(Section section)
        {
            try
            {
                if (section == null)
                {
                    return BadRequest();
                }

                var result = await unitOfWork.SectionRepository.Add(section);
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the new section record");
            }
        }
    }
}
