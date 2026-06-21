namespace Vamana.AMS.Core.Models.Masters;

public class ReceiptCodeMasterModel : BaseMasterModel
{
    public int ReceiptCodeId { get; set; } = default!;
    public string ReceiptCodeName { get; set; } = string.Empty;
}
