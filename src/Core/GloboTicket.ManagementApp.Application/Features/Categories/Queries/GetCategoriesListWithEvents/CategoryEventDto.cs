using System;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; } 
        public Guid CategoryId { get; set; }
       
    }
}