using System;
using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class DeterminationModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}