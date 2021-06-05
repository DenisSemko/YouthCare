using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork unitOfWork;

        public SectionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Section>> Get()
        {
            return await unitOfWork.SectionRepository.Get();
        }

        public async Task<Section> Add(Section section)
        {
            var result = await unitOfWork.SectionRepository.Add(section);
            return result;
        }

    }
}
