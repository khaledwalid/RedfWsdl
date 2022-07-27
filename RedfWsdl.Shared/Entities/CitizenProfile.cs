using System;
using System.ComponentModel.DataAnnotations.Schema;
using RedfWsdl.Shared.Enums;
using RedfWsdl.Shared.Shared;

namespace RedfWsdl.Shared.Entities
{
    public class CitizenProfile : Entity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public string FullName { get; set; }
        public Gender Gender { get; set; }

        public LifeStatus LifeStatus { get; set; }

        public MaritalStatus  MaritalStatus { get; set; }
        
        public int Dependents { get; set; }
    }
}