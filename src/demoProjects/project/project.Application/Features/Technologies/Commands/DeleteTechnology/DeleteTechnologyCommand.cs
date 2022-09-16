using AutoMapper;
using MediatR;
using project.Application.Features.Technologies.Dtos;
using project.Application.Features.Technologies.Rules;
using project.Application.Services.Repositories;
using project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }


        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                var entity = _technologyRepository.Get(t => t.Id == request.Id);
                _technologyBusinessRules.TechnologyShouldExistWhenRequested(entity);

                Technology mappedTechnology = _mapper.Map<Technology>(entity);
                Technology deletedTechnology = _technologyRepository.Delete(entity);
                DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);

                return deletedTechnologyDto;
            }

        }
    }
}
