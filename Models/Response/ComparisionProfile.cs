namespace Intelliflo.Finance.Service.Models.Response
{
    public class IncomeStatistics
    {
        public decimal FirstQuartile { get; set; }
        public decimal Median { get; set; }
        public decimal ThirdQuartile { get; set; }
        public decimal Average { get; set; }
    }

    public class AgeGroupIncome
    {
        public IncomeStatistics Under18 { get; set; }
        public IncomeStatistics From18To24 { get; set; }
        public IncomeStatistics From25To34 { get; set; }
        public IncomeStatistics From35To44 { get; set; }
        public IncomeStatistics From45To54 { get; set; }
        public IncomeStatistics From55To64 { get; set; }
        public IncomeStatistics Over65 { get; set; }
    }

    public class GenderIncome
    {
        public AgeGroupIncome Male { get; set; }
        public AgeGroupIncome Female { get; set; }
    }

    public class IncomeComparison
    {
        public string Id { get; set; } = "income-comparison";
        public string Description { get; set; } = "parameters of gross monthly income based on gender and age";
        public GenderIncome Values { get; set; }
    }

}
