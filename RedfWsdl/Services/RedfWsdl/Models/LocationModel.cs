using System;
using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class LocationModel
    {
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string Building { get; set; }
        [DataMember]
        public string MailBox { get; set; }
    }
}