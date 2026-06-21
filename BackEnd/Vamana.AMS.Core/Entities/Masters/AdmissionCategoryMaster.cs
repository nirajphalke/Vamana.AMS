using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class AdmissionCategoryMaster: BaseEntity
{
    [Key]
    public int AdmissionCategoryId { get; set; }
    public string AdmissionCategoryName { get; set; } = string.Empty;
    public string AdmissionCategoryLongName { get; set; } = string.Empty;

}
