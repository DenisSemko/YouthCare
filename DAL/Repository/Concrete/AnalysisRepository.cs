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

    }
}
