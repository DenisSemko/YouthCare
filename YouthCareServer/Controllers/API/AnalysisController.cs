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
using Microsoft.EntityFrameworkCore;
using DAL;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysService analysService;

        public AnalysisController(IAnalysService analysService)
        {
            this.analysService = analysService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analysis>>> Get()
        {
            return Ok(await analysService.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Analysis>> GetById(Guid id)
        {
            try
            {
                var result = await analysService.GetById(id);

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
        public async Task<ActionResult<Analysis>> Add(AnalysisDto analysisDto)
        {
            try
            {
                if (analysisDto == null)
                {
                    return BadRequest();
                }

                var result = await analysService.Add(analysisDto);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Analysis>> DeleteById(Guid id)
        {
            try
            {
                var result = await analysService.DeleteById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting the analysis record");
            }
        }
    }
}
