
namespace Intelliflo.Finance.Service.Models
{
    public class CreditProfileRequest
    {
        public required Requestor Requestor { get; set; }
        public required NumericInquiry NumericInquiry { get; set; }
    }
}
