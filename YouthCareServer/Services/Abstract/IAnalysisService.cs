using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Models;

namespace YouthCareServer.Services.Abstract
{
    public interface IAnalysisService
    {
        Task<Analysis> Update(Analysis analysis);
    }
}
