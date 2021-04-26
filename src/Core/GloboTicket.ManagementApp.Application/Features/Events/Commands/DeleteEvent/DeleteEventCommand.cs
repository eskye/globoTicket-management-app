using System;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}