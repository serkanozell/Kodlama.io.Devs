using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDublicateWhenInserted(string name)
        {
            IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(t => t.Name == name);
            if (technologies.Items.Any()) throw new BusinessException("Technology already exists");
        }
    }
}
