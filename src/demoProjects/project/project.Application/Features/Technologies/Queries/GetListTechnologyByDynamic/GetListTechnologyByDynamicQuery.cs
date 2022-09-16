using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace project.Application.Features.Technologies.Queries.GetListTechnologyByDynamic
{
    public class GetListTechnologyByDynamicQuery : IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetListTechnologyByDynamicQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> technologies = await _technologyRepository.GetListByDynamicAsync(
                                                                                                request.Dynamic,
                                                                                                include:
                                                                                                t => t.Include(x => x.Language),
                                                                                                index: request.PageRequest.Page,
                                                                                                size: request.PageRequest.PageSize
                                                                                                );

                TechnologyListModel mappedTechnologyListModel = _mapper.Map<TechnologyListModel>(technologies);

                return mappedTechnologyListModel;
            }
        }
    }
}
