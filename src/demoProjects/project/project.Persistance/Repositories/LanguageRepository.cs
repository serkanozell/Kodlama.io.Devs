using Core.Persistence.Repositories;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using project.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Persistence.Repositories
{
    public class LanguageRepository : EfRepositoryBase<Language, BaseDbContext>, ILanguageRepository
    {
        public LanguageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
