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
        private readonly ISectionService sectionService;

        public SectionController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> Get()
        {
            return Ok(await sectionService.Get());
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

                var result = await sectionService.Add(section);
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
