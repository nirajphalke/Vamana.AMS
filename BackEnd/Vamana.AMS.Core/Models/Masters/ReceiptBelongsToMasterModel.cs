namespace Vamana.AMS.Core.Models.Masters;

public class ReceiptBelongsToMasterModel : BaseMasterModel
{
    public int ReceiptBelongsToId { get; set; } = default!;
    public string ReceiptBelongsToName { get; set; } = string.Empty;
}
