using System;
using System.ComponentModel.DataAnnotations.Schema;
using RedfWsdl.Shared.Enums;
using RedfWsdl.Shared.Shared;

namespace RedfWsdl.Shared.Entities
{
    public class Loan : Entity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        
        public int RequestNumber { get; set; }
        public int ContractNumber { get; set; }
        public ContractStatus ContractStatus { get; set; }
        
        public int SadadInvoiceNumber { get; set; }

        public bool UpdateInformationStatus { get; set; }

        public int InstallmentNumber { get; set; }
        public DateTime InstallmentDate { get; set; }
        public decimal InstallmentValue { get; set; }
        
        public decimal OriginalInstallment { get; set; }

        public decimal InstallmentBenefits { get; set; }

        public decimal MonthlySupport { get; set; }

        public decimal AmountPaid { get; set; }
        
        public DateTime PaymentDate { get; set; }

        public DateTime SupportConversionDate { get; set; }
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int IbanNumber { get; set; }
        public bool BenefitCase { get; set; }

        public string Statement { get; set; }

    }
}