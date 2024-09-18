using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TLiability
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LiabilitiesId { get; set; }

    [Required]
    public int CRMContactId { get; set; }
    public int? CRMContactId2 { get; set; }

    public string CommitedOutgoings { get; set; }

    public string Description { get; set; }

    public decimal Amount { get; set; }

    public string Owner { get; set; } = "Client1";
}