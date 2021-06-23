using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.DTOs;
using CIL.Models;

namespace DAL.Repository.Abstract
{
    public interface IAnalysisRepository : IRepository<Analysis>
    {
        Task<Analysis> GetAnalysisByUserId(Guid id);
        Task<IEnumerable<Analysis>> GetBySectionUserType(Guid id, string type);
    }
}
