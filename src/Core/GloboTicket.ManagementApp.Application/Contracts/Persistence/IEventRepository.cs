using GloboTicket.ManagementApp.Domain.Entities;

namespace GloboTicket.ManagementApp.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        
    }
}