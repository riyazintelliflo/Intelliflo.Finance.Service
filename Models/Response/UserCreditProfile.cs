
namespace Intelliflo.Finance.Service.Models.Response
{
    public class UserCreditProfile
    {
      
        public List<AddressInformation> AddressInformation { get; set; }
        public ConsumerIdentity ConsumerIdentity { get; set; }
        public List<EmploymentInformation> EmploymentInformation { get; set; }
     
        public List<RiskModel> RiskModel { get; set; }
        public string Ssn { get; set; }
        public List<Summary> Summaries { get; set; }

        public List<Tradeline> Tradeline { get; set; }
        public FinicityVerificationOfAssets Assets { get; set; }
    }

    //   public List<Tradeline> Tradeline { get; set; }
    // public List<EndTotal> EndTotals { get; set; }
    //  public List<FraudShield> FraudShield { get; set; }
    //   public List<Summary> Summaries { get; set; }
    // public List<HeaderRecord> HeaderRecord { get; set; } = [];

}
