using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class TreatmentService : ITreatmentService
    {
        private readonly IUnitOfWork unitOfWork;

        public TreatmentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Treatment>> Get()
        {
            return await unitOfWork.TreatmentRepository.Get();
        }

        public async Task<Treatment> GetById(Guid id)
        {
            var result = await unitOfWork.TreatmentRepository.GetById(id);
            return result;
        }

        public async Task<Treatment> Add(Treatment treatment)
        {
            var result = await unitOfWork.TreatmentRepository.Add(treatment);
            return result;
        }

        public async Task<Treatment> Update(Treatment treatment)
        {
            var result = await unitOfWork.TreatmentRepository.Update(treatment);
            return result;
        }

        public async Task<Treatment> DeleteById(Guid id)
        {
            var result = await unitOfWork.TreatmentRepository.DeleteById(id);
            return result;
        }
    }
}
