using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface ITreatmentService
    {
        public Task<IEnumerable<Treatment>> Get();
        public Task<Treatment> GetById(Guid id);
        public Task<Treatment> Add(Treatment item);
        public Task<Treatment> Update(Treatment item);
        public Task<Treatment> DeleteById(Guid id);
    }
}
