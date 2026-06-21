using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class BranchMaster: BaseEntity
{
    [Key]
    public int BranchId { get; set; }
    public string BranchCode { get; set; } = string.Empty;
    public string BranchLongName { get; set; } = string.Empty;
    public string BranchShortName { get; set; } = string.Empty;
}
