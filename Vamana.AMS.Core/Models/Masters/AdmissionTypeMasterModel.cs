namespace Vamana.AMS.Core.Models.Masters;

public class AdmissionTypeMasterModel : BaseMasterModel
{
    public int AdmissionTypeId { get; set; } = default!;
    public string AdmissionTypeName { get; set; } = string.Empty;
}
