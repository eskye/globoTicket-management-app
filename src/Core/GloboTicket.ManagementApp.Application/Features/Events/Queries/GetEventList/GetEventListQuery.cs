using System.Collections.Generic;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventListDto>>
    {
        
    }
}