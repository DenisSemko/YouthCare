using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Repository.Concrete
{
    public class AnalysisResultRepository : BaseRepository<Analysis>, IAnalysisResultRepository
    {
        public AnalysisResultRepository(ApplicationContext myDbContext) : base(myDbContext) { }

        public async Task<IEnumerable<Analysis>> GetByUserId(Guid id)
        {
            var result = await myDbContext.Analysis.Where(o => o.SportsmanUserId.Id == id).Include(o => o.SportsmanUserId).Include(o => o.DoctorUserId).ToListAsync();
            return result;
        }
    }
}
