using System;
using System.Runtime.Serialization;

namespace RedfWsdl.Services.RedfWsdl.Models
{
    [DataContract]
    public class LoginOutputModel
    {
        [DataMember]
        public int IdentificationNumber { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}