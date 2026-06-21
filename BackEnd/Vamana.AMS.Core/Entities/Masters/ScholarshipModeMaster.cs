using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class ScholarshipModeMaster : BaseEntity
{
    [Key]
    public int ScholarshipModeId { get; set; }
    public string ScholarshipModeName { get; set; } = string.Empty;
}
