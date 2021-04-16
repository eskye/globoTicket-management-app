using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery : IRequest<CategoryEventListDto>
    {
        public bool IncludeHistory { get; set; }
    }
}