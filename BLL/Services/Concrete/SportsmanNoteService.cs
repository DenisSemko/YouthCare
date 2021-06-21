using BLL.Services.Abstract;
using CIL.DTOs;
using CIL.Models;
using DAL;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class SportsmanNoteService : ISportsmanNoteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationContext myDbContext;

        public SportsmanNoteService(IUnitOfWork unitOfWork, ApplicationContext myDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.myDbContext = myDbContext;
        }

        public async Task<IEnumerable<SportsmanNote>> Get()
        {
            return await unitOfWork.SportsmanNoteRepository.Get();
        }

        public async Task<IEnumerable<SportsmanNote>> GetByUserId(Guid id)
        {
            var result = await unitOfWork.SportsmanNoteRepository.GetByUserId(id);
            return result;
        }

        public async Task<SportsmanNote> Add(SportsmanNote note)
        {
            var result = await unitOfWork.SportsmanNoteRepository.Add(note);
            return result;
        }
        public async Task<SportsmanNote> Add(NoteDto note)
        {
            var selectedSportsman = await myDbContext.Users.Where(c => c.Id == note.SportsmanUserId).FirstOrDefaultAsync();

            var sportsmanNote = new SportsmanNote
            {
                Id = note.Id,
                SportsmanUserId = selectedSportsman,
                Title = note.Title.Trim(),
                Description = note.Description.Trim(),
                Date = note.Date
            };

            var result = await unitOfWork.SportsmanNoteRepository.Add(sportsmanNote);

            return result;
        }

        public async Task<SportsmanNote> Update(SportsmanNote note)
        {
            var result = await unitOfWork.SportsmanNoteRepository.Update(note);
            return result;
        }
        public async Task<SportsmanNote> Update(NoteDto sportsmanNote)
        {
            var selectedSportsman = await myDbContext.Users.Where(c => c.Id == sportsmanNote.SportsmanUserId).FirstOrDefaultAsync();
            var note = new SportsmanNote()
            {
                Id = sportsmanNote.Id,
                SportsmanUserId = selectedSportsman,
                Title = sportsmanNote.Title,
                Description = sportsmanNote.Description,
                Date = sportsmanNote.Date
            };
            var result = await unitOfWork.SportsmanNoteRepository.Update(note);
            return result;
        }

        public async Task<SportsmanNote> DeleteById(Guid id)
        {
            var result = await unitOfWork.SportsmanNoteRepository.DeleteById(id);
            return result;
        }
    }
}
