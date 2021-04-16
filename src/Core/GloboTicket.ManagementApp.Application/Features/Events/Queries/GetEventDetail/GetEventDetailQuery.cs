using System;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<EventDetailDto>
    {
        public Guid Id { get; set; }
    }
}