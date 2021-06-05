using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class AnalysisResultService : IAnalysisResultService
    {
        private readonly IAnalysisResultRepository analysisRepository;
        public AnalysisResultService(IAnalysisResultRepository analysisRepository)
        {
            this.analysisRepository = analysisRepository;
        }

        public async Task<IEnumerable<Analysis>> GetByUserId(Guid id)
        {
            var result = await analysisRepository.GetByUserId(id);
            return result;
        }
    }
}
