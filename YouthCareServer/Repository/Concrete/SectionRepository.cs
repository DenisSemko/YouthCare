using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Models;
using YouthCareServer.Repository.Abstract;

namespace YouthCareServer.Repository.Concrete
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(ApplicationContext myDbContext) : base(myDbContext) { }
    }
}
