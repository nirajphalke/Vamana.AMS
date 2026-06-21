using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class DistrictMaster: BaseEntity
{
    [Key]
    public int DistrictId { get; set; }
    public int StateId { get; set; }
    public string DistrictName { get; set; } = default!;
    // Navigation property
    public StateMaster State { get; set; } = default!;
    // Navigation property
    public ICollection<CityMaster> Cities { get; set; } = new List<CityMaster>();
}
