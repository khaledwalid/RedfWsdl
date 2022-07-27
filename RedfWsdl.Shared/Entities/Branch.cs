using System.ComponentModel.DataAnnotations;
using RedfWsdl.Shared.Shared;

namespace RedfWsdl.Shared.Entities
{
    public class Branch : Entity
    {
        [Key]
        public string Code { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string Location { get; set; }
    }
}