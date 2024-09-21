namespace Intelliflo.Finance.Service.Models
{
    public class IOClientPortfolio
    {
        public int CRMContactId { get; set; }

        // Asset data
        public IList<TAsset>? Asset { get; set; }
        public IList<TLiability>? Liability { get; set; }
    }
}