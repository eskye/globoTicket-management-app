using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.ManagementApp.Application.Contracts.Persistence;
using GloboTicket.ManagementApp.Application.Exceptions;
using GloboTicket.ManagementApp.Domain.Entities;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            
            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);
            return @event.EventId;
        }
        
    }
}