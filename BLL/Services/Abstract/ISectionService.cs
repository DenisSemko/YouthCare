using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface ISectionService
    {
        public Task<IEnumerable<Section>> Get();
        public Task<Section> Add(Section item);
    }
}
