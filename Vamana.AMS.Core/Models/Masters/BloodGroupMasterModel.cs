namespace Vamana.AMS.Core.Models.Masters;

public class BloodGroupMasterModel
{
    public int BloodGroupId { get; set; } = default!;
    public string BloodGroupName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = default!;
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string IPAddress { get; set; } = string.Empty;
    public string MACAddress { get; set; } = string.Empty;
    public int OrganizationId { get; set; }
}
