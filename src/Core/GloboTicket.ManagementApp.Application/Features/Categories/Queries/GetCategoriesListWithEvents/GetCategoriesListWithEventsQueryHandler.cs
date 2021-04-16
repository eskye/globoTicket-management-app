using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.ManagementApp.Application.Contracts.Persistence; 
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery,CategoryEventListDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryEventListDto> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var categoriesWithEvents = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<CategoryEventListDto>(categoriesWithEvents);
        }
    }
}