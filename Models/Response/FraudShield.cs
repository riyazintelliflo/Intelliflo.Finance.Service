namespace Intelliflo.Finance.Service.Models.Response
{
    public class FraudShield
    {
        public string AddressCount { get; set; }
        public string AddressDate { get; set; }
        public string AddressErrorCode { get; set; }
        public FraudShieldIndicators FraudShieldIndicators { get; set; }
        public string SocialCount { get; set; }
        public string SocialDate { get; set; }
        public string SocialErrorCode { get; set; }
        public string SsnFirstPossibleIssuanceYear { get; set; }
        public string SsnLastPossibleIssuanceYear { get; set; }
        public string Type { get; set; }
    }

    public class FraudShieldIndicators
    {
        public List<string> Indicator { get; set; }
    }

}
