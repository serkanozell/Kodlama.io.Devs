using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using project.Application.Features.Githubs.Models;
using project.Application.Features.Technologies.Models;
using project.Application.Features.Technologies.Queries.GetListTechnologyByDynamic;
using project.Application.Features.Technologies.Rules;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Queries.GetListGithubProfileByDynamic
{
    public class GetListGithubProfileByDynamicQuery : IRequest<GithubProfileListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListGithubProfileByDynamicQueryHandler : IRequestHandler<GetListGithubProfileByDynamicQuery, GithubProfileListModel>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetListGithubProfileByDynamicQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<GithubProfileListModel> Handle(GetListGithubProfileByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubProfile> githubProfiles = await _githubProfileRepository.GetListByDynamicAsync(
                                                                                                request.Dynamic,
                                                                                                //include:
                                                                                                //t => t.Include(x => x.Language),
                                                                                                index: request.PageRequest.Page,
                                                                                                size: request.PageRequest.PageSize
                                                                                                );

                GithubProfileListModel mappedGithubProfilesListModel = _mapper.Map<GithubProfileListModel>(githubProfiles);

                return mappedGithubProfilesListModel;
            }
        }
    }
}
