using System;
using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class ServiceModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string NameArabic { get; set; }
        [DataMember]
        public string NameEnglish { get; set; }
        [DataMember]
        public string Location { get; set; }
    }
}