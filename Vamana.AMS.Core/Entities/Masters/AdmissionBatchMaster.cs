using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class AdmissionBatchMaster : BaseEntity
{
    [Key]
    public int AdmissionBatchId { get; set; } = default!;
    public string AdmissionBatchName { get; set; } = string.Empty;
}
