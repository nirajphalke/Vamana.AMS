using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class InstituteMaster: BaseEntity
{
    [Key]
    public int InstituteId { get; set; }
    public string InstituteName { get; set; } = string.Empty;
}
