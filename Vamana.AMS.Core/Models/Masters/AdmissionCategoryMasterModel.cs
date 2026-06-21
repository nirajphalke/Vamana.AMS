namespace Vamana.AMS.Core.Models.Masters;

public class AdmissionCategoryMasterModel : BaseMasterModel
{
    public int AdmissionCategoryId { get; set; } = default!;
    public string AdmissionCategoryName { get; set; } = string.Empty;
    public string AdmissionCategoryLongName { get; set; } = string.Empty;
}
