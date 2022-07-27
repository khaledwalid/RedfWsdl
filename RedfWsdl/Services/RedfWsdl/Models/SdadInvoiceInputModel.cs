using System;
using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class SdadInvoiceInputModel
    {
        [DataMember]
        public int IdentificationNumber { get; set; }
        [DataMember]
        public Guid ServiceId { get; set; }
        [DataMember]
        public DateTime SupportConversionDate { get; set; }

    }
}