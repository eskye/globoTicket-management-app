using System;
using GloboTicket.ManagementApp.Domain.Common;

namespace GloboTicket.ManagementApp.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
        
    }
}