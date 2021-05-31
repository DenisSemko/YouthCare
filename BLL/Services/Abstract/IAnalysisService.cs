using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;

namespace BLL.Services.Abstract
{
    public interface IAnalysisService
    {
        Task<Analysis> Update(Analysis analysis);
    }
}
