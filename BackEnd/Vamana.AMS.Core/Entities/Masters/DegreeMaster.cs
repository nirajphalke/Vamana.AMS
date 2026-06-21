using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class DegreeMaster: BaseEntity
{
    [Key]
    public int DegreeId { get; set; }
    public string DegreeCode { get; set; } = string.Empty;
    public string DegreeName { get; set; } = string.Empty;
}
