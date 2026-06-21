using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class BloodGroupMaster: BaseEntity
{
    [Key]
    public int BloodGroupId { get; set; } = default!;
    public string BloodGroupName { get; set; } = string.Empty;
}
