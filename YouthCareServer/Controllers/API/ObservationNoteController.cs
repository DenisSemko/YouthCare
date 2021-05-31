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
    public class ObservationNoteController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ObservationNoteController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObservationNote>>> Get()
        {
            return Ok(await unitOfWork.ObservationNoteRepository.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ObservationNote>> GetById(Guid id)
        {
            try
            {
                var result = await unitOfWork.ObservationNoteRepository.GetById(id);

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
        public async Task<ActionResult<ObservationNote>> Add(ObservationNote observationNote)
        {
            try
            {
                if (observationNote == null)
                {
                    return BadRequest();
                }

                var result = await unitOfWork.ObservationNoteRepository.Add(observationNote);
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the new note record");
            }
        }


        /*[HttpPut]
        public async Task<ActionResult<ObservationNote>> Update(ObservationNote observationNote)
        {
            var result = await observationNoteRepository.Update(observationNote);
            return result;
        }*/

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ObservationNote>> DeleteById(Guid id)
        {
            try
            {
                var result = await unitOfWork.ObservationNoteRepository.DeleteById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting the note record");
            }
        }
    }
}
