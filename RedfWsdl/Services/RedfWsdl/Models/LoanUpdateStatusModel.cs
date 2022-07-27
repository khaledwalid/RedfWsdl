using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]

    public class LoanUpdateStatusModel
    {
        [DataMember]
        public bool UpdateInformationStatus { get; set; }
    }
}