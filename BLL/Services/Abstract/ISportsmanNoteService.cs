using CIL.DTOs;
using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface ISportsmanNoteService
    {
        public Task<IEnumerable<SportsmanNote>> Get();
        public Task<IEnumerable<SportsmanNote>> GetByUserId(Guid id);
        public Task<SportsmanNote> Add(SportsmanNote item);
        public Task<SportsmanNote> Add(NoteDto item);
        public Task<SportsmanNote> Update(SportsmanNote item);
        public Task<SportsmanNote> Update(NoteDto item);
        public Task<SportsmanNote> DeleteById(Guid id);
    }
}
