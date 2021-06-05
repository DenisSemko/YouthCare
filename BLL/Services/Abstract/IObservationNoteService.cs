using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IObservationNoteService
    {
        public Task<IEnumerable<ObservationNote>> Get();
        public Task<ObservationNote> GetById(Guid id);
        public Task<ObservationNote> Add(ObservationNote item);
        public Task<ObservationNote> Update(ObservationNote item);
        public Task<ObservationNote> DeleteById(Guid id);
    }
}
