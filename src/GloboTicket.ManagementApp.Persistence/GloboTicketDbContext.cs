using System;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.ManagementApp.Domain.Common;
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
            var concertedGuid = Guid.Parse("99a6342d-6a05-4031-be59-65fdc3fc8014");
            var musicalGuid = Guid.Parse("7431793a-6a6b-49c3-a621-fb8f8e73cd51");
            var playGuid = Guid.Parse("14714ba9-882f-4f2c-91cd-30089ddc9ba2");
            var conferenceGuid = Guid.Parse("d7b17583-1a70-439b-a393-fd0cce8acef0");
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
               EventId = Guid.Parse("cf93f8f3-0bd5-45bd-b576-bff501378ff4"),
               Name = "Musical Concert Rapper Night Show",
               Price = 6500,
               Artist = "Pako Hustler",
               Description = "Musical rapper night show is a musical concert that brings all musician together to perform their various best rapping songs in the last 4 years.",
               Date = DateTime.Now,
               ImageUrl = "",
               CategoryId = concertedGuid
            });


            modelBuilder.Entity<Order>().HasData(new Order
            {
              Id = Guid.Parse("f4250b79-60ef-4fba-8e8b-1bcd56f840b2"),
              OrderTotal = 116,
              OrderPaid = true,
              OrderPlaced = DateTime.Now,
              UserId = Guid.Parse("5cd55432-d9c2-4a12-87dd-72f95b78108d")
            });
            
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("83a62e90-b96f-480e-ac54-4bd8b502c1c7"),
                OrderTotal = 120,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("91a47cac-ca28-4c6f-bda8-5aaf74e7be23")
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}