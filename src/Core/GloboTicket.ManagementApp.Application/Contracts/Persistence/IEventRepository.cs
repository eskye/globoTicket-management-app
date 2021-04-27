using System;
using System.Threading.Tasks;
using GloboTicket.ManagementApp.Domain.Entities;

namespace GloboTicket.ManagementApp.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}