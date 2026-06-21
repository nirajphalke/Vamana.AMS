using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class AdmissionThroughMaster : BaseEntity
{
    [Key]
    public int AdmissionThroughId { get; set; }
    public string AdmissionThroughName { get; set; } = string.Empty;
}
