using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.DTOs;
using YouthCareServer.Models;
using YouthCareServer.Repository.Abstract;

namespace YouthCareServer.Repository.Concrete
{
    public class AnalysisRepository : BaseRepository<Analysis>, IAnalysisRepository
    {
        public AnalysisRepository(ApplicationContext myDbContext) : base(myDbContext) { }

    }
}
