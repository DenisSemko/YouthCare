using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class SportsmanNoteService : ISportsmanNoteService
    {
        private readonly IUnitOfWork unitOfWork;

        public SportsmanNoteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SportsmanNote>> Get()
        {
            return await unitOfWork.SportsmanNoteRepository.Get();
        }

        public async Task<SportsmanNote> GetById(Guid id)
        {
            var result = await unitOfWork.SportsmanNoteRepository.GetById(id);
            return result;
        }

        public async Task<SportsmanNote> Add(SportsmanNote note)
        {
            var result = await unitOfWork.SportsmanNoteRepository.Add(note);
            return result;
        }

        public async Task<SportsmanNote> Update(SportsmanNote note)
        {
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
