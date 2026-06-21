namespace Vamana.AMS.Core.Models.Masters;

public class CountryMasterModel
{
    public int CountryId { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = default!;
    public int? CreatedBy { get; set; } 
    public DateTime CreatedDate { get; set; }
    public int? ModifiedBy { get; set; } 
    public DateTime? ModifiedDate { get; set; }
    public string IPAddress { get; set; } = string.Empty;
    public int OrganizationId { get; set; }
    public string MACAddress { get; set; } = string.Empty;
}
