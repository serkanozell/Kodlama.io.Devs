using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Githubs.Rules
{
    public class GithubProfileBusinessRules
    {
        private readonly IGithubProfileRepository _githubRepository;

        public GithubProfileBusinessRules(IGithubProfileRepository githubRepository)
        {
            _githubRepository = githubRepository;
        }

        public async Task GithubProfileNameCanNotBeDuplicatedWhenInserted(string repositoryName)
        {
            IPaginate<GithubProfile> result = await _githubRepository.GetListAsync(g => g.RepositoryName == repositoryName);
            if (result.Items.Any()) throw new BusinessException("Github Profile exists");
        }

        public void GithubProfileShouldExistWhenRequested(GithubProfile githubProfile)
        {
            if (githubProfile == null) throw new BusinessException("Requested Profile does not exist");
        }

        public async Task GithubCanNotBeSameAsEntityModelWhenUpdated(string repositoryName)
        {
            var result = await _githubRepository.GetAsync(g => g.RepositoryName == repositoryName);
            if (result != null) throw new BusinessException("Repository name and your request is same");
        }
    }
}
