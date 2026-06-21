using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class AdmissionYearMaster: BaseEntity
{
    [Key]
    public int AdmissionYearId { get; set; }
    public string AdmissionYearName { get; set; } = string.Empty;
}
