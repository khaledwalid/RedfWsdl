using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]

    public class SdadInvoiceModel
    {
        [DataMember]
        public int SadadInvoiceNumber { get; set; }

    }
}