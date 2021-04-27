using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.ManagementApp.Application.Contracts.Persistence;
using GloboTicket.ManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.ManagementApp.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly GloboTicketDbContext _globoTicketDb;

        public CategoryRepository(GloboTicketDbContext globoTicketDb) : base(globoTicketDb)
        {
            _globoTicketDb = globoTicketDb;
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _globoTicketDb.Categories.Include(e => e.Events)
                                              .ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }

            return allCategories;
        }
    }
}