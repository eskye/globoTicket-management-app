using System;

namespace GloboTicket.ManagementApp.Application.Features.Events.Queries.GetEventDetail
{
    public class EventDetailDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}