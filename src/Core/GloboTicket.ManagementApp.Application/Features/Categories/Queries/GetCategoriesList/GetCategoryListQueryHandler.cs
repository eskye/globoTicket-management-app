using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.ManagementApp.Application.Contracts.Persistence; 
using GloboTicket.ManagementApp.Domain.Entities;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _catergoryRepository;

        public GetCategoryListQueryHandler(IMapper mapper, IAsyncRepository<Category> catergoryRepository)
        {
            _mapper = mapper;
            _catergoryRepository = catergoryRepository;
        }
        public async Task<List<CategoryListDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = (await _catergoryRepository.ListAllAsync())
                                                  .OrderBy(d => d.Name);
            return _mapper.Map<List<CategoryListDto>>(categories);
        }
    }
}