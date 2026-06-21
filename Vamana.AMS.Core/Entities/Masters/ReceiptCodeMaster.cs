using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class ReceiptCodeMaster : BaseEntity
{
    [Key]
    public int ReceiptCodeId { get; set; }
    public string ReceiptCodeName { get; set; } = string.Empty;
    public ICollection<ReceiptTypeMaster>? ReceiptTypeMasters { get; set; }
}
