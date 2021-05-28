using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Models;
using YouthCareServer.Services.Abstract;
using YouthCareServer.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using YouthCareServer.DTOs;
using AutoMapper;


namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisResultController : ControllerBase
    {
        private readonly IAnalysisService analysisService;
        private readonly ApplicationContext myDbContext;
        private readonly IMapper mapper;
        public AnalysisResultController(IAnalysisService analysisService, ApplicationContext myDbContext, IMapper mapper)
        {
            this.analysisService = analysisService;
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<Analysis>>> GetByUserId(Guid id)
        {
            try
            {
                var result = await myDbContext.Analysis.Where(o => o.SportsmanUserId.Id == id).Include(o => o.SportsmanUserId).Include(o => o.DoctorUserId).ToListAsync();

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<Analysis> Update(AnalysisDto analysisDto)
        {
            try
            {
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
                await analysisService.Update(analysis);
                return analysis;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
