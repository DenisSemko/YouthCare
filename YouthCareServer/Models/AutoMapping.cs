using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YouthCareServer.DTOs;

namespace YouthCareServer.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserDto, User>();
            CreateMap<AnalysisDto, Analysis>()
                 .ForMember(d => d.SportsmanUserId, o => o.MapFrom(s => s))
                 .ForMember(d => d.DoctorUserId, o => o.MapFrom(s => s));
            CreateMap<AnalysisDto, User>();
        }
    }
}
