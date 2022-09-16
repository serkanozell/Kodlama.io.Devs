using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using project.Application.Features.Technologies.Models;
using project.Application.Features.Technologies.Rules;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery : IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(include:
                                                                                        t => t.Include(x => x.Language),
                                                                                        index: request.PageRequest.Page,
                                                                                        size: request.PageRequest.PageSize
                                                                                        );

                TechnologyListModel mappedListTechnology = _mapper.Map<TechnologyListModel>(technologies);

                return mappedListTechnology;
            }
        }
    }
}
