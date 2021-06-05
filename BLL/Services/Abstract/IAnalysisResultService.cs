using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IAnalysisResultService
    {
        public Task<IEnumerable<Analysis>> GetByUserId(Guid id);
    }
}
