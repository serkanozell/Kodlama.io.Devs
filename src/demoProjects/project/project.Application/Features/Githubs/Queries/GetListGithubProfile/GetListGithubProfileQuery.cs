using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using project.Application.Features.Githubs.Dtos;
using project.Application.Features.Githubs.Models;
using project.Application.Features.Technologies.Models;
using project.Application.Features.Technologies.Queries.GetListTechnology;
using project.Application.Features.Technologies.Rules;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Queries.GetListGithubProfile
{
    public class GetListGithubProfileQuery : IRequest<GithubProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGithubProfileQueryHandler : IRequestHandler<GetListGithubProfileQuery, GithubProfileListModel>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetListGithubProfileQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<GithubProfileListModel> Handle(GetListGithubProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubProfile> githubProfile = await _githubProfileRepository.GetListAsync(/*include:*/
                                                                                        ///*t => t.Include(x => x.User*/),
                                                                                        index: request.PageRequest.Page,
                                                                                        size: request.PageRequest.PageSize
                                                                                        );

                GithubProfileListModel mappedGithubProfileListModel = _mapper.Map<GithubProfileListModel>(githubProfile);

                return mappedGithubProfileListModel;
            }
        }
    }
}
