using System;
using System.ComponentModel.DataAnnotations.Schema;
using RedfWsdl.Shared.Enums;
using RedfWsdl.Shared.Shared;

namespace RedfWsdl.Shared.Entities
{
    public class Request : Entity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int RequestNumber { get; set; }

        public RequestStatus RequestStatus { get; set; }
    }
}