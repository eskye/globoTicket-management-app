using System;
using System.Collections.Generic;
using GloboTicket.ManagementApp.Domain.Common;

namespace GloboTicket.ManagementApp.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}