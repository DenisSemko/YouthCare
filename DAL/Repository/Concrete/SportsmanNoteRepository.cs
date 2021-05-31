using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class SportsmanNoteRepository : BaseRepository<SportsmanNote>, ISportsmanNoteRepository
    {
        public SportsmanNoteRepository(ApplicationContext myDbContext) : base(myDbContext) { }
    }
}
