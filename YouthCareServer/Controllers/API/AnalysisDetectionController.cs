using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BLL.Services.Abstract;
using CIL.Models;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisDetectionController : ControllerBase
    {
        private readonly IAnalysisDetectionService analysisDetectionService;
        public AnalysisDetectionController(IAnalysisDetectionService analysisDetectionService)
        {
            this.analysisDetectionService = analysisDetectionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysisDetection>>> Get()
        {
            return Ok(await analysisDetectionService.Get());
        }

        [HttpPost]
        public async Task<ActionResult<AnalysisDetection>> Add(AnalysisDetection analysis)
        {
            try
            {
                if (analysis == null)
                {
                    return BadRequest();
                }

                var result = await analysisDetectionService.Add(analysis);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<AnalysisDetection>> DeleteByUserId(Guid id)
        {
            try
            {
                var result = await analysisDetectionService.DeleteByUserId(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
