using System.Runtime.Serialization;
using RedfWsdl.Shared.Enums;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]

    public class CitizenProfileModel
    {
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public Gender Gender { get; set; }
        [DataMember]
        public LifeStatus LifeStatus { get; set; }
        [DataMember]
        public MaritalStatus MaritalStatus { get; set; }

        [DataMember]
        public int Dependents { get; set; }

    }
}