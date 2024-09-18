public class TAssetsAndLiabilities
{
    
    public int CRMContactId { get; set; }

    // Asset data
    public IList<TAsset> Asset { get; set; }
    public IList<TLiability> Liability { get; set; }
}