using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class ReligionMaster: BaseEntity
{
    [Key]
    public int ReligionId { get; set; } = default!;
    public string ReligionName { get; set; } = string.Empty;
}

