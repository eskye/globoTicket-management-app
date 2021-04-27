using System;
using GloboTicket.ManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.ManagementApp.Persistence
{
    public class GloboTicketDbContext : DbContext
    {
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options):base(options)
        {
        }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);
            //Seed data, added through migration
            var concertedGuid = Guid.Parse("");
            var musicalGuid = Guid.Parse("");
            var playGuid = Guid.Parse("");
            var conferenceGuid = Guid.Parse("");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
            {
               CategoryId = concertedGuid,
               Name = "Concerts"
            });
            
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musics"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
               EventId = Guid.Parse(""),
               Name = "Musical Concert Rapper Night Show",
               Price = 6500,
               Artist = "Pako Hustler",
               Description = "Musical rapper night show is a musical concert that brings all musician together to perform their various best rapping songs in the last 4 years.",
               Date = DateTime.Now,
               ImageUrl = "",
               CategoryId = concertedGuid
            });
        }
    }
}