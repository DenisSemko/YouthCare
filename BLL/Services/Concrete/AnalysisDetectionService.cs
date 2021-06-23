using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class AnalysisDetectionService : IAnalysisDetectionService
    {
        private readonly IUnitOfWork unitOfWork;

        public AnalysisDetectionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AnalysisDetection>> Get()
        {
            return await unitOfWork.AnalysisDetectionRepository.Get();
        }

        public async Task<AnalysisDetection> Add(AnalysisDetection analysis)
        {
            var result = await unitOfWork.AnalysisDetectionRepository.Add(analysis);
            return result;
        }

        public async Task<AnalysisDetection> DeleteByUserId(Guid id)
        {
            var result = await unitOfWork.AnalysisDetectionRepository.DeleteByUserId(id);
            return result;
        }
    }
}
