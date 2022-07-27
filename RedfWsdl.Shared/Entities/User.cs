using System;
using System.ComponentModel.DataAnnotations.Schema;
using RedfWsdl.Shared.Enums;
using RedfWsdl.Shared.Shared;

namespace RedfWsdl.Shared.Entities
{
    public class User : Entity
    {
        public int NationalId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdentificationNumber { get; set; }

        [ForeignKey("Parent")]
        public Guid? ParentId { get; set; }
        public virtual User Parent { get; set; }
        public RelationShipStatus? RelationShipStatus { get; set; }
        public DateTime BirthDate { get; set; }
    }
}