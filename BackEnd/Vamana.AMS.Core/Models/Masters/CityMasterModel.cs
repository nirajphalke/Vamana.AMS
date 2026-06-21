namespace Vamana.AMS.Core.Models.Masters;

public class CityMasterModel
{
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    //public int StateId { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string DistrictName { get; set; } = string.Empty;
    //public string StateName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = default!;
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string IPAddress { get; set; } = string.Empty;
    public int OrganizationId { get; set; }
    public string MACAddress { get; set; } = string.Empty;
}
