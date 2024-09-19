using System.ComponentModel.DataAnnotations.Schema;

namespace Intelliflo.Finance.Service.Models
{
    [Table("TEmailReference")]
    public class TEmailReference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReferalId { get; set; }
    }

}
