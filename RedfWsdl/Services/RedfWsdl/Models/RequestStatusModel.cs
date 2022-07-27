using System.Runtime.Serialization;
using RedfWsdl.Shared.Enums;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class RequestStatusModel
    {
        [DataMember]
        public RequestStatus RequestStatus { get; set; }
    }
}