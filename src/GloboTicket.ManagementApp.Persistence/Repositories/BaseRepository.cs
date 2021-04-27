using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.ManagementApp.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.ManagementApp.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly GloboTicketDbContext _globoTicketDb;

        public BaseRepository(GloboTicketDbContext globoTicketDb)
        {
            _globoTicketDb = globoTicketDb;
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _globoTicketDb.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _globoTicketDb.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _globoTicketDb.Set<T>().AddAsync(entity);
            await _globoTicketDb.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _globoTicketDb.Entry(entity).State = EntityState.Modified;
            await _globoTicketDb.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _globoTicketDb.Set<T>().Remove(entity);
            await _globoTicketDb.SaveChangesAsync();
        }
    }
}