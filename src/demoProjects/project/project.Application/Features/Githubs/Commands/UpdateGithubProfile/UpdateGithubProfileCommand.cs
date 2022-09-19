using AutoMapper;
using MediatR;
using project.Application.Features.Githubs.Dtos;
using project.Application.Features.Githubs.Rules;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommand : IRequest<UpdateGithubProfileDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RepositoryName { get; set; }
        public string Url { get; set; }

        public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdateGithubProfileDto>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public UpdateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<UpdateGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                await _githubProfileBusinessRules.GithubCanNotBeSameAsEntityModelWhenUpdated(request.RepositoryName);

                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile updatedGithubProfile = await _githubProfileRepository.UpdateAsync(mappedGithubProfile);

                UpdateGithubProfileDto updateGithubProfileDto = _mapper.Map<UpdateGithubProfileDto>(updatedGithubProfile);

                return updateGithubProfileDto;
            }
        }
    }
}
