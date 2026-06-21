using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class AdmissionTypeMaster: BaseEntity
{
    [Key]
    public int AdmissionTypeId { get; set; }
    public string AdmissionTypeName { get; set; } = string.Empty;
}
