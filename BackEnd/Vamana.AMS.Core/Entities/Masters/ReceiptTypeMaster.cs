using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class ReceiptTypeMaster : BaseEntity
{
    [Key]
    public int ReceiptTypeId { get; set; }
    public string ReceiptTypeName { get; set; } = string.Empty;
    public int ReceiptCodeId { get; set; }
    public int ReceiptBelongsTo { get; set;}
    public string AccountNo { get; set; } = string.Empty;
    public bool LinkWithAccounts { get; set; } = default!;
    public bool IsAdmissionType { get; set; } = default!;
    public bool IsLateFineApplicable { get; set; } = default!;
    public bool ShowInStudentLogin { get; set; } = default!;
    public bool IsOnlineVisibility { get; set; } = default!;

    // Navigation properties
    public ReceiptCodeMaster? ReceiptCodeMaster { get; set; }
    public ReceiptBelongsToMaster? ReceiptBelongsToMaster { get; set; }
}
