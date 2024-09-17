using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;

namespace Intelliflo.Finance.Service.Models.Response
{
    public class CreditProfile
    {
        public List<HeaderRecord> HeaderRecord { get; set; }
        public List<AddressInformation> AddressInformation { get; set; }
        public ConsumerIdentity ConsumerIdentity { get; set; }
        public List<EmploymentInformation> EmploymentInformation { get; set; }
        public List<FraudShield> FraudShield { get; set; }
        public List<InformationalMessage> InformationalMessage { get; set; }
        public List<Inquiry> Inquiry { get; set; }
        public List<Summary> Summaries { get; set; }
        public List<RiskModel> RiskModel { get; set; }
        public List<Ssn> Ssn { get; set; }
        public List<Tradeline> Tradeline { get; set; }
        public UniqueConsumerIdentifier UniqueConsumerIdentifier { get; set; }
        public List<EndTotal> EndTotals { get; set; }
    }

}
