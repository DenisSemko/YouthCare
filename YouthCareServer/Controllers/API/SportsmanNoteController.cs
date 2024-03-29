﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using CIL.DTOs;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsmanNoteController : ControllerBase
    {
        private readonly ISportsmanNoteService sportsmanNoteService;

        public SportsmanNoteController(ISportsmanNoteService sportsmanNoteService)
        {
            this.sportsmanNoteService = sportsmanNoteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportsmanNote>>> Get()
        {
            return Ok(await sportsmanNoteService.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<SportsmanNote>>> GetByUserId(Guid id)
        {
            try
            {
                var result = await sportsmanNoteService.GetByUserId(id);

                if (result == null) return NotFound();

                return result.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SportsmanNote>> Add(NoteDto sportsmanNote)
        {
            try
            {
                if (sportsmanNote == null)
                {
                    return BadRequest();
                }

                var result = await sportsmanNoteService.Add(sportsmanNote);

                if (string.IsNullOrWhiteSpace(sportsmanNote.Description) || string.IsNullOrWhiteSpace(sportsmanNote.Title))
                {
                    return BadRequest("You cannot create an empty note");
                }

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the new note record");
            }
        }


       [HttpPut]
        public async Task<ActionResult<SportsmanNote>> Update(NoteDto sportsmanNote)
        {
            var result = await sportsmanNoteService.Update(sportsmanNote);
            return result;
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<SportsmanNote>> DeleteById(Guid id)
        {
            try
            {
                var result = await sportsmanNoteService.DeleteById(id);

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
