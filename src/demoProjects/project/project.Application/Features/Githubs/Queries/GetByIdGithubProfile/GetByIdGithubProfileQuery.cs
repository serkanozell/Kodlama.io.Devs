using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using project.Application.Features.Githubs.Dtos;
using project.Application.Features.Githubs.Rules;
using project.Application.Features.Technologies.Dtos;
using project.Application.Features.Technologies.Queries.GetByIdTechnology;
using project.Application.Features.Technologies.Rules;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Queries.GetByIdGithubProfile
{
    public class GetByIdGithubProfileQuery : IRequest<GithubProfileGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdGithubProfileQueryHandler : IRequestHandler<GetByIdGithubProfileQuery, GithubProfileGetByIdDto>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public GetByIdGithubProfileQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<GithubProfileGetByIdDto> Handle(GetByIdGithubProfileQuery request, CancellationToken cancellationToken)
            {
                GithubProfile? githubProfile = await _githubProfileRepository.GetAsync(t => t.Id == request.Id/*, include: p => p.Include(x => x.UserId)*/);
                _githubProfileBusinessRules.GithubProfileShouldExistWhenRequested(githubProfile);

                GithubProfileGetByIdDto githubProfileGetByIdDto = _mapper.Map<GithubProfileGetByIdDto>(githubProfile);

                return githubProfileGetByIdDto;
            }
        }
    }
}
