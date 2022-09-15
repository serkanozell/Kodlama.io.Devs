using Core.Persistence.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Services.Repositories
{
    public interface ITechnologyRepository : IAsyncRepository<Technology>, IRepository<Technology>
    {
    }
}
