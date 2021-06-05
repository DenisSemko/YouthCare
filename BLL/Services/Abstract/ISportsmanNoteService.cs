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
        public Task<SportsmanNote> GetById(Guid id);
        public Task<SportsmanNote> Add(SportsmanNote item);
        public Task<SportsmanNote> Update(SportsmanNote item);
        public Task<SportsmanNote> DeleteById(Guid id);
    }
}
