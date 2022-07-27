using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class LoanBenefitModel
    {
        [DataMember]
        public bool BenefitCase { get; set; }

    }
}