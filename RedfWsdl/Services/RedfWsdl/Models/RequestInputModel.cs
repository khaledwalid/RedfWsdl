using System;
using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class RequestInputModel
    {
        public int IdentificationNumber { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime RequestDate { get; set; }
    }
}