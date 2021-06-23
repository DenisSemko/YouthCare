using BLL.Services.Abstract;
using CIL.DTOs;
using CIL.Models;
using DAL;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class AnalysService : IAnalysService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationContext myDbContext;
        public AnalysService(IUnitOfWork unitOfWork, ApplicationContext myDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.myDbContext = myDbContext;
        }

        public async Task<IEnumerable<Analysis>> Get()
        {
            return await unitOfWork.AnalysisRepository.Get();
        }

        public async Task<Analysis> GetById(Guid id)
        {
            var result = await unitOfWork.AnalysisRepository.GetById(id);
            return result;
        }

        public async Task<IEnumerable<Analysis>> GetBySectionUserType(Guid id, string type)
        {
            var result = await unitOfWork.AnalysisRepository.GetBySectionUserType(id, type);
            return result;
        }

        public async Task<Analysis> Add(Analysis analysis)
        {
            var result = await unitOfWork.AnalysisRepository.Add(analysis);
            return result;
        }

        public async Task<Analysis> Add(AnalysisDto analysisDto)
        {
            var selectedSportsman = await myDbContext.Users.Where(c => c.Id == analysisDto.SportsmanUserId).FirstOrDefaultAsync();
            var selectedDoctor = await myDbContext.Users.Where(c => c.Id == analysisDto.DoctorUserId).FirstOrDefaultAsync();

            var analysis = new Analysis
            {
                Id = analysisDto.Id,
                SportsmanUserId = selectedSportsman,
                DoctorUserId = selectedDoctor,
                Name = analysisDto.Name,
                Date = analysisDto.Date,
                Type = analysisDto.Type,
                Measure = analysisDto.Measure,
                Weight = analysisDto.Weight,
                Height = analysisDto.Height,
                Description = analysisDto.Description,
                Result = analysisDto.Result

            };

            var result = await unitOfWork.AnalysisRepository.Add(analysis);

            return result;
        }

        public async Task<Analysis> Update(Analysis analysis)
        {
            var result = await unitOfWork.AnalysisRepository.Update(analysis);
            return result;
        }

        public async Task<Analysis> DeleteById(Guid id)
        {
            var result = await unitOfWork.AnalysisRepository.DeleteById(id);
            return result;
        }


    }
}
