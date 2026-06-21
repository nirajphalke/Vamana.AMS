namespace Vamana.AMS.Core.Models.Masters;

public class ReceiptTypeMasterModel : BaseMasterModel
{
    public int ReceiptTypeId { get; set; } = default!;
    public string ReceiptTypeName { get; set; } = string.Empty;
    public int ReceiptCodeId { get; set; }
    public string ReceiptCodeName { get; set; } = string.Empty;
    public int ReceiptBelongsTo { get; set; }
    public string ReceiptBelongsToName { get; set; } = string.Empty;
    public string AccountNo { get; set; } = string.Empty;
    public bool LinkWithAccounts { get; set; } = default!;
    public bool IsAdmissionType { get; set; } = default!;
    public bool IsLateFineApplicable { get; set; } = default!;
    public bool ShowInStudentLogin { get; set; } = default!;
    public bool IsOnlineVisibility { get; set; } = default!;
}
