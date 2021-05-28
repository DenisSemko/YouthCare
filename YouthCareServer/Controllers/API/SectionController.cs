using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Models;
using YouthCareServer.Services.Abstract;
using YouthCareServer.Repository.Abstract;
using Microsoft.AspNetCore.Http;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository sectionRepository;

        public SectionController(ISectionRepository sectionRepository)
        {
            this.sectionRepository = sectionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> Get()
        {
            return Ok(await sectionRepository.Get());
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

                var result = await sectionRepository.Add(section);
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
