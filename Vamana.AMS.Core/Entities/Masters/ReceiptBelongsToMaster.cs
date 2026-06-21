using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class ReceiptBelongsToMaster : BaseEntity
{
    [Key]
    public int ReceiptBelongsToId { get; set; }
    public string ReceiptBelongsToName { get; set; } = string.Empty;
    public ICollection<ReceiptTypeMaster>? ReceiptTypeMasters { get; set; }
}
