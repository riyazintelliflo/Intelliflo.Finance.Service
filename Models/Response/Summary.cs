namespace Intelliflo.Finance.Service.Models.Response
{
    public class Summary
    {
        public string SummaryType { get; set; }
        public List<UserAttribute> Attributes { get; set; }
    }

    public class UserAttribute
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

}
