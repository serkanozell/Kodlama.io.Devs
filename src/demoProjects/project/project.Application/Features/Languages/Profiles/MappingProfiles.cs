using AutoMapper;
using Core.Persistence.Paging;
using project.Application.Features.Languages.Commands.CreateLanguage;
using project.Application.Features.Languages.Commands.DeleteLanguage;
using project.Application.Features.Languages.Commands.UpdateLanguage;
using project.Application.Features.Languages.Dtos;
using project.Application.Features.Languages.Models;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();

            CreateMap<Language, DeletedLanguageDto>().ReverseMap();
            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();

            CreateMap<Language, UpdatedLanguageDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            CreateMap<Language, LanguageListDto>().ReverseMap();

            CreateMap<Language, LanguageGetByIdDto>().ReverseMap();
        }
    }
}
