using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.DTOs;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class AnalysisRepository : BaseRepository<Analysis>, IAnalysisRepository
    {
        public AnalysisRepository(ApplicationContext myDbContext) : base(myDbContext) 
        {
        }

        public new async Task<ActionResult<Analysis>> GetById(Guid id)
        {
            var result = await myDbContext.Analysis.Where(o => o.Id == id).Include(o => o.SportsmanUserId).Include(o => o.DoctorUserId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Analysis> GetAnalysisByUserId(Guid id)
        {
            var analysis = await myDbContext.Analysis
                .Where(a => a.SportsmanUserId.Id == id)
                .Where(a => a.DoctorUserId != null)
                .Where(a => a.Description == null)
                .Where(a => a.Result == null)
                .Where(m => m.Measure != 0)
                .Include(a => a.SportsmanUserId)
                .Include(a => a.DoctorUserId).FirstOrDefaultAsync();
            return analysis;
        }

        public async Task<IEnumerable<Analysis>> GetBySectionUserType(Guid id, string type)
        {
            try
            {
                var result = await myDbContext.Analysis.Where(o => o.SportsmanUserId.BelongSection.Id == id).Where(o => o.SportsmanUserId.UserType == type).Include(o => o.SportsmanUserId.BelongSection).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
