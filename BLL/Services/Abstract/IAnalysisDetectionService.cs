using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IAnalysisDetectionService
    {
        public Task<IEnumerable<AnalysisDetection>> Get();
        public Task<AnalysisDetection> Add(AnalysisDetection item);
        public Task<AnalysisDetection> DeleteByUserId(Guid id);
    }
}
