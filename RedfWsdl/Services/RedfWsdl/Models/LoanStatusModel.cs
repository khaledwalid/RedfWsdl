using System.Runtime.Serialization;
using RedfWsdl.Shared.Enums;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]

    public class LoanStatusModel
    {
        [DataMember]
        public ContractStatus ContractStatus { get; set; }
    }
}