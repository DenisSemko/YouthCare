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
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentRepository treatmentRepository;

        public TreatmentController(ITreatmentRepository treatmentRepository)
        {
            this.treatmentRepository = treatmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treatment>>> Get()
        {
            return Ok(await treatmentRepository.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Treatment>> GetById(Guid id)
        {
            try
            {
                var result = await treatmentRepository.GetById(id);

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
        public async Task<ActionResult<Treatment>> Add(Treatment treatment)
        {
            try
            {
                if (treatment == null)
                {
                    return BadRequest();
                }

                var result = await treatmentRepository.Add(treatment);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /*[HttpPut]
        public async Task<ActionResult<Treatment>> Update(Treatment treatment)
        {
            var result = await treatmentRepository.Update(treatment);
            return result;
        }*/

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Treatment>> DeleteById(Guid id)
        {
            try
            {
                var result = await treatmentRepository.DeleteById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting the treatment record");
            }
        }
    }
}
