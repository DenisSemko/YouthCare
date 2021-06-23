using CIL.DTOs;
using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IAnalysService
    {
        public Task<IEnumerable<Analysis>> Get();
        public Task<Analysis> GetById(Guid id);
        public Task<IEnumerable<Analysis>> GetBySectionUserType(Guid id, string type);
        public Task<Analysis> Add(Analysis item);
        public Task<Analysis> Add(AnalysisDto item);
        public Task<Analysis> Update(Analysis item);
        public Task<Analysis> DeleteById(Guid id);
    }
}
