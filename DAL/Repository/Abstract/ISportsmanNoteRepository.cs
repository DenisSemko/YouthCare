using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.DTOs;
using CIL.Models;

namespace DAL.Repository.Abstract
{
    public interface ISportsmanNoteRepository : IRepository<SportsmanNote>
    {
        public new Task<IEnumerable<SportsmanNote>> Get();
        public Task<IEnumerable<SportsmanNote>> GetByUserId(Guid id);
    }
}
