using RedfWsdl.Shared.Shared;

namespace RedfWsdl.Shared.Entities
{
    public class Crm : Entity
    {
        public int ContractNumber { get; set; }
        public string Recommendation { get; set; }
        public string FundsRecommendation { get; set; }
    }
}