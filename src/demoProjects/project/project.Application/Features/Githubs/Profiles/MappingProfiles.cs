using AutoMapper;
using Core.Persistence.Paging;
using project.Application.Features.Githubs.Dtos;
using project.Application.Features.Githubs.Models;
using project.Application.Features.Languages.Commands.CreateLanguage;
using project.Application.Features.Languages.Commands.UpdateLanguage;
using project.Application.Features.Languages.Dtos;
using project.Application.Features.Languages.Models;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreatedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, CreateLanguageCommand>().ReverseMap();

            CreateMap<GithubProfile, DeletedGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, DeleteGithubProfileCommand>().ReverseMap();

            CreateMap<GithubProfile, UpdateGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, UpdatedGithubProfileCommand>().ReverseMap();

            CreateMap<IPaginate<GithubProfile>, GithubProfileListModel>().ReverseMap();
            CreateMap<GithubProfile, GithubProfileListDto>().ReverseMap();

            CreateMap<GithubProfile, GithubProfileGetByIdDto>().ReverseMap();
        }
    }
}
