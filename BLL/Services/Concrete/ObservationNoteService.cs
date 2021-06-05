using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class ObservationNoteService : IObservationNoteService
    {
        private readonly IUnitOfWork unitOfWork;

        public ObservationNoteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ObservationNote>> Get()
        {
            return await unitOfWork.ObservationNoteRepository.Get();
        }

        public async Task<ObservationNote> GetById(Guid id)
        {
            var result = await unitOfWork.ObservationNoteRepository.GetById(id);
            return result;
        }

        public async Task<ObservationNote> Add(ObservationNote note)
        {
            var result = await unitOfWork.ObservationNoteRepository.Add(note);
            return result;
        }

        public async Task<ObservationNote> Update(ObservationNote note)
        {
            var result = await unitOfWork.ObservationNoteRepository.Update(note);
            return result;
        }

        public async Task<ObservationNote> DeleteById(Guid id)
        {
            var result = await unitOfWork.ObservationNoteRepository.DeleteById(id);
            return result;
        }
    }
}
