namespace Intelliflo.Finance.Service.Models
{
    public class NumericInquiry
    {
        public string? AddressNumber { get; set; }
        public string? AddressZip { get; set; }
        public required string Ssn { get; set; }
        public required IDType IdType { get; set; }

    }

}
