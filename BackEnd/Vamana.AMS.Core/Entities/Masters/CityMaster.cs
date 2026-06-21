using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class CityMaster: BaseEntity
{
    [Key]
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    //public int StateId { get; set; }
    public string CityName { get; set; } = default!;
    // Navigation property
    public DistrictMaster District { get; set; } = default!;
    //public StateMaster State { get; set; } = default!;
}
