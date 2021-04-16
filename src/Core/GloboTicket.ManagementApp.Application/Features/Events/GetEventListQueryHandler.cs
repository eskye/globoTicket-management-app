using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.ManagementApp.Application.Contracts.Persistence;
using GloboTicket.ManagementApp.Domain.Entities;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Events
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Event> _eventRepository;

        public GetEventListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<List<EventListDto>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var events = (await _eventRepository.ListAllAsync())
                                                  .OrderBy(d => d.Date);
            return _mapper.Map<List<EventListDto>>(events);
        }
    }
}