using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelliflo.Finance.Service.Models
{
    [Table("TContact")]
    public class TContact
    {
        [Key]
        public int ContactId { get; set; }
        public int IndClientId { get; set; }
        public int CrmContactId { get; set; }
        public string RefContactType { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

    }
}
