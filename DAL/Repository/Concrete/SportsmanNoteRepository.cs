using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.DTOs;
using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Concrete
{
    public class SportsmanNoteRepository : BaseRepository<SportsmanNote>, ISportsmanNoteRepository
    {
        public SportsmanNoteRepository(ApplicationContext myDbContext) : base(myDbContext) { }

        public new async Task<IEnumerable<SportsmanNote>> Get()
        {
            var result = await myDbContext.SportsmanNote.Include(o => o.SportsmanUserId).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<SportsmanNote>> GetByUserId(Guid id)
        {
            var result = await myDbContext.SportsmanNote.Where(o => o.SportsmanUserId.Id == id).Include(o => o.SportsmanUserId).ToListAsync();
            return result;
        }
        
    }
}
