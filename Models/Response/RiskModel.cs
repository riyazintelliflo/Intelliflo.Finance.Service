namespace Intelliflo.Finance.Service.Models.Response
{
    public class RiskModel
    {
        public string Evaluation { get; set; }
        public string ModelIndicator { get; set; }
        public string Score { get; set; }
        public List<ScoreFactor> ScoreFactors { get; set; }
    }

    public class ScoreFactor
    {
        public string Importance { get; set; }
        public string Code { get; set; }
    }

}
