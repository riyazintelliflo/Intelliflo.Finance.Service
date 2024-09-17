namespace Intelliflo.Finance.Service.Models.Response
{
    public class Summary
    {
        public string SummaryType { get; set; }
        public List<Attribute> Attributes { get; set; }
    }

    public class Attribute
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

}
