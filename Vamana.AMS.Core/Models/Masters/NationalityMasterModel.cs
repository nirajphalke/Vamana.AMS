namespace Vamana.AMS.Core.Models.Masters;

public class NationalityMasterModel
{
    public int NationalityId { get; set; }
    public string NationalityName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string IPAddress { get; set; } = string.Empty;
    public string MACAddress { get; set; } = string.Empty;
    public int OrganizationId { get; set; }
}
