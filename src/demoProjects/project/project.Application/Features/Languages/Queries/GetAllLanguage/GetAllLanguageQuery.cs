using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using project.Application.Features.Languages.Models;
using project.Application.Features.Languages.Queries.GetListLanguage;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Languages.Queries.GetAllLanguage
{
    public class GetAllLanguageQuery : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQuery, LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetAllLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetAllLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> languages = await _languageRepository.GetListAsync();

                LanguageListModel mappedLanguageListModel = _mapper.Map<LanguageListModel>(languages);

                return mappedLanguageListModel;
            }
        }
    }
}
