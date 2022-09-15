using Core.Persistence.Repositories;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using project.Persistance.Contexts;

namespace project.Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
