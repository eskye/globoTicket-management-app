using System;
using System.Collections.Generic;
using GloboTicket.ManagementApp.Domain.Entities;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}