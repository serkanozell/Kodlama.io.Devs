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

namespace project.Application.Features.Githubs.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommand : IRequest<DeletedGithubProfileDto>
    {
        public int Id { get; set; }

        public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeletedGithubProfileDto>
        {
            private readonly IGithubProfileRepository _githubRepository;
            private readonly IMapper _mapper;
            private readonly GithubProfileBusinessRules _githubProfileBusinessRules;

            public DeleteGithubProfileCommandHandler(IGithubProfileRepository githubRepository, IMapper mapper, GithubProfileBusinessRules githubProfileBusinessRules)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
                _githubProfileBusinessRules = githubProfileBusinessRules;
            }

            public async Task<DeletedGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
            {
                var entity = _githubRepository.Get(g => g.Id == request.Id);

                _githubProfileBusinessRules.GithubProfileShouldExistWhenRequested(entity);

                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(entity);
                GithubProfile deletedGithubProfile = await _githubRepository.DeleteAsync(mappedGithubProfile);

                DeletedGithubProfileDto deletedGithubProfileDto = _mapper.Map<DeletedGithubProfileDto>(deletedGithubProfile);

                return deletedGithubProfileDto;
            }
        }
    }
}
