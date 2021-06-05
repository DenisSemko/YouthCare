using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IAnalysisResultRepository : IRepository<Analysis>
    {
        public Task<IEnumerable<Analysis>> GetByUserId(Guid id);
    }
}
