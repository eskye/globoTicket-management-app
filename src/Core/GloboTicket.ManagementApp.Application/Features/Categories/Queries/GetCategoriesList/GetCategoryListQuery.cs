using System.Collections.Generic;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListDto>>
    {
        
    }
}