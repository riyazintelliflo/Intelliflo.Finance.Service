using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TAssets")]
public class TAsset
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AssetsId { get; set; }

    [Required]
    public int CRMContactId { get; set; }

    public int? CRMContactId2 { get; set; }

    [MaxLength(512)]
    public string Owner { get; set; }

    [MaxLength(512)]
    public string Description { get; set; }

    [Column(TypeName = "money")]
    public decimal? Amount { get; set; }

    [MaxLength(3)]
    public string CurrencyCode { get; set; }

    // Foreign key for TAssetCategory
    public int AssetCategoryId { get; set; }

    // Navigation property for related TAssetCategory entity
    [ForeignKey("AssetCategoryId")]
    public TAssetCategory TAssetCategory { get; set; }
}


public class TAssetCategory
{
    [Key]
    public int AssetCategoryId { get; set; }
    
    [MaxLength(512)]
    public string CategoryName { get; set; }

    // Navigation property for related TAsset entities
    //public ICollection<TAsset> TAssets { get; set; }
}
