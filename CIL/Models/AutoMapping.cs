using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CIL.DTOs;

namespace CIL.Models
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
            CreateMap<NoteDto, SportsmanNote>()
                 .ForMember(d => d.SportsmanUserId, o => o.MapFrom(s => s.SportsmanUserId));
            CreateMap<Message, MessageDto>()
                .ForMember(d => d.SenderId, o => o.MapFrom(s => s.SenderId.Id))
                .ForMember(d => d.RecepientId, o => o.MapFrom(s => s.RecepientId.Id));
        }
    }
}
