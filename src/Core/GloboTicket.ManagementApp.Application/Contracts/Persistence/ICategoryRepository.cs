using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.ManagementApp.Domain.Entities;

namespace GloboTicket.ManagementApp.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}