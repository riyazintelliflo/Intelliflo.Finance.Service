namespace Intelliflo.Finance.Service.Models.Response
{
    public class Tradeline
    {
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string Amount1 { get; set; }
        public string Amount1Qualifier { get; set; }
        public string Amount2 { get; set; }
        public string Amount2Qualifier { get; set; }
        public string AmountPastDue { get; set; }
        public string BalanceAmount { get; set; }
        public string BalanceDate { get; set; }
        public string Delinquencies30Days { get; set; }
        public string Delinquencies60Days { get; set; }
        public string Delinquencies90to180Days { get; set; }
        public string DerogCounter { get; set; }
        public string Ecoa { get; set; }
        public EnhancedPaymentData EnhancedPaymentData { get; set; }
        public string Evaluation { get; set; }
        public string Kob { get; set; }
        public string LastPaymentDate { get; set; }
        public string MonthsHistory { get; set; }
        public string OpenDate { get; set; }
        public string OpenOrClosed { get; set; }
        public string PaymentHistory { get; set; }
        public string RevolvingOrInstallment { get; set; }
        public string SpecialComment { get; set; }
        public string Status { get; set; }
        public string StatusDate { get; set; }
        public string SubscriberCode { get; set; }
        public string SubscriberName { get; set; }
        public string Terms { get; set; }
    }

    public class EnhancedPaymentData
    {
        public string ChargeoffAmount { get; set; }
        public string CreditLimitAmount { get; set; }
        public string EnhancedAccountCondition { get; set; }
        public string EnhancedAccountType { get; set; }
        public string EnhancedPaymentHistory84 { get; set; }
        public string EnhancedPaymentStatus { get; set; }
        public string EnhancedSpecialComment { get; set; }
        public string EnhancedTerms { get; set; }
        public string EnhancedTermsFrequency { get; set; }
        public string FirstDelinquencyDate { get; set; }
        public string HighBalanceAmount { get; set; }
        public string PaymentLevelDate { get; set; }
        public string SecondDelinquencyDate { get; set; }
    }

}
