using System;
using System.ComponentModel.DataAnnotations.Schema;
using RedfWsdl.Shared.Shared;

namespace RedfWsdl.Shared.Entities
{
    public class Location : Entity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string MailBox { get; set; }
    }
}