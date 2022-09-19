using Core.Persistence.Repositories;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using project.Persistance.Contexts;

namespace project.Persistence.Repositories
{
    public class GithubProfileRepository : EfRepositoryBase<GithubProfile, BaseDbContext>, IGithubProfileRepository
    {
        public GithubProfileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
