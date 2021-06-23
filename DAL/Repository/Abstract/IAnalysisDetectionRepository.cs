using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IAnalysisDetectionRepository : IRepository<AnalysisDetection>
    {
        Task<AnalysisDetection> DeleteByUserId(Guid id);
    }
}
