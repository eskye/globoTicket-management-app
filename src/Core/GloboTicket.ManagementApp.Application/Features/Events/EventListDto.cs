using System;

namespace GloboTicket.ManagementApp.Application.Features.Events
{
    public class EventListDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}