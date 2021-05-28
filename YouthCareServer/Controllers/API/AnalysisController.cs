using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Models;
using YouthCareServer.Services.Abstract;
using YouthCareServer.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using YouthCareServer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisRepository analysisRepository;
        private readonly ApplicationContext myDbContext;

        public AnalysisController(IAnalysisRepository analysisRepository, ApplicationContext myDbContext)
        {
            this.analysisRepository = analysisRepository;
            this.myDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analysis>>> Get()
        {
            return Ok(await analysisRepository.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Analysis>> GetById(Guid id)
        {
            try
            {
                var result = await myDbContext.Analysis.Where(o => o.Id == id).Include(o => o.SportsmanUserId).Include(o => o.DoctorUserId).FirstOrDefaultAsync();

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

                var selectedSportsman = await myDbContext.Users.Where(c => c.Id == analysisDto.SportsmanUserId).FirstOrDefaultAsync();
                var selectedDoctor = await myDbContext.Users.Where(c => c.Id == analysisDto.DoctorUserId).FirstOrDefaultAsync();
                var analysis = new Analysis
                {
                    Id = analysisDto.Id,
                    SportsmanUserId = selectedSportsman,
                    DoctorUserId = selectedDoctor,
                    Name = analysisDto.Name,
                    Date = analysisDto.Date,
                    Type = analysisDto.Type,
                    Measure = analysisDto.Measure,
                    Weight = analysisDto.Weight,
                    Height = analysisDto.Height,
                    Description = analysisDto.Description,
                    Result = analysisDto.Result

                };
                var result = await analysisRepository.Add(analysis);
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
                var result = await analysisRepository.DeleteById(id);

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
