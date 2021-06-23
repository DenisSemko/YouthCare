using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
{
    public class AnalysisDetectionRepository : BaseRepository<AnalysisDetection>, IAnalysisDetectionRepository
    {
        public AnalysisDetectionRepository(ApplicationContext myDbContext) : base(myDbContext) { }

        public async Task<AnalysisDetection> DeleteByUserId(Guid id)
        {
            var user = await myDbContext.AnalysisDetection.Where(o => o.SportsmanId == id).FirstOrDefaultAsync();
            var result = myDbContext.AnalysisDetection.Remove(user);
            await myDbContext.SaveChangesAsync();
            return user;
        }

    }
}
