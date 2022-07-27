using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class RequestNumberModel
    {
        [DataMember]
        public int RequestNumber { get; set; }
    }
}