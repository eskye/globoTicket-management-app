using System.Collections.Generic;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Events
{
    public class GetEventListQuery : IRequest<List<EventListDto>>
    {
        
    }
}