using AutoMapper;
using Core.Persistence.Paging;
using project.Application.Features.Languages.Commands.UpdateLanguage;
using project.Application.Features.Technologies.Commands.CreateTechnolgy;
using project.Application.Features.Technologies.Commands.DeleteTechnology;
using project.Application.Features.Technologies.Commands.UpdateTechnology;
using project.Application.Features.Technologies.Dtos;
using project.Application.Features.Technologies.Models;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, TechnologyGetByIdDto>().ForMember(m => m.LanguageName, opt => opt.MapFrom(dest => dest.Language.Name)).ReverseMap();

            CreateMap<Technology, TechnologyListDto>().ForMember(m => m.LanguageName, opt => opt.MapFrom(dest => dest.Language.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}
