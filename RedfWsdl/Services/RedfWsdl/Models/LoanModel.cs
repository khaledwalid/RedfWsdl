using System;
using System.Runtime.Serialization;
using RedfWsdl.Shared.Enums;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class LoanModel
    {
        [DataMember]
        public int ContractNumber { get; set; }
        [DataMember]
        public ContractStatus ContractStatus { get; set; }
        [DataMember]
        public int SadadInvoiceNumber { get; set; }
        [DataMember]
        public bool UpdateInformationStatus { get; set; }
        [DataMember]
        public int InstallmentNumber { get; set; }
        [DataMember]
        public DateTime InstallmentDate { get; set; }
        [DataMember]
        public decimal InstallmentValue { get; set; }
        [DataMember]
        public decimal OriginalInstallment { get; set; }
        [DataMember]
        public decimal InstallmentBenefits { get; set; }
        [DataMember]
        public decimal MonthlySupport { get; set; }
        [DataMember]
        public decimal AmountPaid { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public DateTime SupportConversionDate { get; set; }
        [DataMember]
        public int IbanNumber { get; set; }
        [DataMember]
        public bool BenefitCase { get; set; }
        [DataMember]
        public string Statement { get; set; }
    }
}